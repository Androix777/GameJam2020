using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxHP;
    public int HP;
    public Status status;
    public bool dead = false;

    [SerializeField]
    bool immortal = false;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0 && !dead)
        {
            if (!immortal)
            {
                Functions.DestroyWithDeathEffects(gameObject, deathCause: DeathCause.Kill);
            }
            dead = true;
        }
        else
        {
            dead = false;
            HP = HP > maxHP ? maxHP : HP;
        }

    }


}
