using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    enum Action { Move, Heal, Stay}
    Vector2 Position = new Vector2();
    GameObject target;
    Life lifeTarget;
    Action action;
    Move move;

    [SerializeField]
    float range = 0;
    [SerializeField]
    int heal = 0;
    [SerializeField]
    float coolDown = 0;

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
            Debug.Log(hit.collider.gameObject.name);
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
                    Debug.Log(hit.collider.gameObject.name);
                    action = Action.Move;
                    Position = hit.point;
                }
            }
            else
            {
                action = Action.Stay;
            }
        }
    }

    Action ChooseAction(Life life)
    {
        Debug.Log(life.status);
        if (life.status == Status.Ally)
        {
            lifeTarget = life;
            target = life.gameObject;
            return Action.Heal;
        }
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
                if (lifeTarget != null && timer <= 0)
                {
                    lifeTarget.DealDamage(-heal);
                    timer = coolDown;
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
