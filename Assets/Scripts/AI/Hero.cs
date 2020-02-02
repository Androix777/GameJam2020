using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    enum Action { Move, Heal, Stay}
    Vector2 Position = new Vector2();
    GameObject target;
    Life lifeTarget;
    Action action = Action.Stay;
    Move move;
    [SerializeField]
    ParticleSystem particleHeal;

    [SerializeField]
    public float range = 0;
    [SerializeField]
    public int heal = 0;
    [SerializeField]
    public float coolDown = 0;
    [SerializeField]
    public float energy  = 0;

    float timer = 0;
    

    //float 
    // Start is called before the first frame update
    void Start()
    {
        move = gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseDown();
        switch (action)
        {
            case Action.Move:
                MoveToPoint();
                break;
            case Action.Heal:
                Heal();
                break;
            case Action.Stay:
                Stay();
                break;
        }
        timer = timer > 0 ? timer-Time.deltaTime : 0;
    }

    private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,100);
            if (hit)
            {
                Life filter = hit.collider.GetComponent<Life>();
                if (filter)
                {
                    Debug.Log(filter.gameObject.name);
                    action = ChooseAction(filter);
                }
                else
                {
                    
                    particleHeal.gameObject.SetActive(false);
                    action = Action.Move;
                    Position = hit.point;
                }
            }
            else
            {
                action = Action.Stay;
                particleHeal.gameObject.SetActive(false);
            }
        }
    }

    Action ChooseAction(Life life)
    {
        if (life.status == Status.Ally)
        {
            lifeTarget = life;
            target = life.gameObject;
            return Action.Heal;
        }
        else
        {
            Position = life.gameObject.transform.position;
            return Action.Move;
        }
        particleHeal.gameObject.SetActive(false);
        return Action.Move;
    }

    private void MoveToPoint()
    {
        if (Vector2.Distance((Vector2)transform.position,Position) > 0.1f)
        {
            move.SetMove(Position - (Vector2)transform.position);
        }
        else
        {
            if (action == Action.Move)
            {
                action = Action.Stay;
            }
            
        }
        
    }

    private void Stay()
    {
        move.SetMove(Vector2.zero);
    }

    private void Heal()
    {
        if (target != null)
        {
            if (Vector2.Distance(gameObject.transform.position, target.transform.position) <= range)
            {
                Stay();
                if (lifeTarget != null)
                {
                    if (particleHeal != null && Core.GetEnergy() > energy)
                    {
                        particleHeal.startLifetime = Vector2.Distance(gameObject.transform.position, target.transform.position) / range * 0.7f;
                        particleHeal.gameObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, target.transform.position - transform.position));
                        particleHeal.gameObject.SetActive(true);
                        if (timer <= 0)
                        {
                            Core.SetEnergy(Core.GetEnergy() - energy);
                            lifeTarget.DealDamage(-heal);
                            timer = coolDown;
                        }
                    }
                }
            }
            else
            {

                Position = Vector2.ClampMagnitude((Vector2)transform.position - (Vector2)target.transform.position,range) + (Vector2)target.transform.position;
                MoveToPoint();
            }
        }
        else
        {
            
        }

    }
}
