using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField]
    float range;

    Shooter shooter;
    Life life;

    GameObject target;
    void Start()
    {
        
        shooter = gameObject.GetComponent<Shooter>();
        life = gameObject.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null || Vector2.Distance((Vector2)target.transform.position, (Vector2)transform.position) > range) target = FindTarget();
        else Fire();
    }

    GameObject FindTarget()
    {
        GameObject target = this.target;
        if (target == null || Vector2.Distance((Vector2)target.transform.position,(Vector2)transform.position) > range)
        {
            target = null;
            List<Collider2D> colliders = new List<Collider2D>(Physics2D.OverlapCircleAll(transform.position,range));
            float dist = float.MaxValue;
            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<Life>() && collider.GetComponent<Life>().status == Status.Enemy)
                {
                    if (Vector2.Distance((Vector2)transform.position,(Vector2)collider.transform.position) < dist)
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
            shooter.Shoot((Vector2)transform.position);
        }
    }
}
