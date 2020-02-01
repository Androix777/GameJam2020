using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    enum Action { Move, Heal, Stay}
    [SerializeField]
    Vector2 Position = new Vector2();
    [SerializeField]
    GameObject target;
    [SerializeField]
    Action action;
    [SerializeField]
    Move move;

    [SerializeField]
    float range = 0;
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
    }

    private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray,out hit,10))
            {
                Life filter = hit.collider.GetComponent<Life>();
                if (filter)
                {
                    Debug.Log(filter.gameObject.name);
                    action = ChooseAction();
                }
                else
                {
                    action = Action.Move;
                    Position = hit.point;
                }
            }
            else action = Action.Stay;

        }
    }

    Action ChooseAction()
    {
        return Action.Move;
    }

    private void MoveToPoint()
    {
        Debug.Log("M");
        if (Vector2.Distance((Vector2)transform.position,Position) > 0.1f)
        {
            move.SetMove(Position - (Vector2)transform.position);
        }
        else
        {
            action = Action.Stay;
        }
        
    }

    private void Stay()
    {
        Debug.Log("S");
        move.SetMove(Vector2.zero);
    }

    private void Heal()
    {
        Debug.Log("H");
        if (target != null)
        {
            if (Vector2.Distance(gameObject.transform.position, target.transform.position) <= range)
            {
                Stay();
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
