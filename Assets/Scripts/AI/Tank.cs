using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    Move move;
    [SerializeField]
    float range;
    [SerializeField]
    float rangeVert;
    Shooter shooter;
    Life life;

    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        CreateMoveDirection(Vector2.left);
    }

    void Update()
    {
        if (target == null) 
        {
            target = FindTarget();
            CreateMoveDirection(Vector2.left);
        }
        else
        {
            if (Mathf.Abs(target.transform.position.x - transform.position.x) > range)
            {
                CreateMoveDirection(Vector2.left);
            }
            else
            {
                if (Mathf.Abs(transform.position.y - target.transform.position.y) > rangeVert)
                {
                    CreateMoveDirection(Vector2.left);
                }
                else
                {
                    Fire();
                    CreateMoveDirection(Vector2.zero);
                }
            }
        }
    }

    void CreateMoveDirection(Vector2 vector)
    {
        if (move != null)
        {
            if (Vector2.zero == vector)
            {
                move.Stop();
            }
            else
            {
                move.SetMove(vector);
            }
            
        }
            
    }

    void Attack()
    {

    }

    GameObject FindTarget()
    {
        GameObject target = this.target;
        if (target == null || Vector2.Distance((Vector2)target.transform.position, (Vector2)transform.position) > range)
        {
            target = null;
            List<Collider2D> colliders = new List<Collider2D>(Physics2D.OverlapCircleAll(transform.position, range));
            float dist = float.MaxValue;
            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<Life>() && collider.GetComponent<Life>().status == Status.Ally && !collider.GetComponent<Life>().dead)
                {
                    if (Vector2.Distance((Vector2)transform.position, (Vector2)collider.transform.position) < dist)
                    {
                        dist = Vector2.Distance((Vector2)transform.position, (Vector2)collider.transform.position);
                        target = collider.gameObject;
                    }
                }
            }
        }
        return target;
    }

    void Fire()
    {
        bool b = true;
        if (life != null)
        {
            b = !life.dead;
        }
        if (shooter != null && b)
        {
            shooter.Shoot((Vector2)target.transform.position - (Vector2)transform.position);
        }
    }

}
