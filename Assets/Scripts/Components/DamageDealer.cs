using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    public Status status;
    public bool destroyAfterDealDamage;    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        DealDamage(col.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        DealDamage(col.gameObject);
    }

    private void DealDamage(GameObject target)
    {
        if (target.GetComponent<Life>() && !target.GetComponent<Life>().dead)
        {
            if (target.GetComponent<UpgradeReflect>() != null && target.GetComponent<UpgradeReflect>().reflectChance > Random.Range(0, 100))
            {
                this.transform.Rotate(new Vector3(0, 0, this.transform.rotation.z + 180));
                gameObject.GetComponent<Rigidbody2D>().velocity *= -1;
                gameObject.GetComponent<DamageDealer>().status = Status.Ally;
                return;
            }
            if (target.GetComponent<Life>() != null && target.GetComponent<Life>().status != status)
            {
                target.GetComponent<Life>().DealDamage(damage);
                if (destroyAfterDealDamage) Functions.DestroyWithDeathEffects(gameObject, deathCause: DeathCause.Time);
            }
        }
    }
}
