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
        HP = HP - damage < 0 ? 0 : HP - damage;
        if (HP <= 0 && !dead)
        {
            if (!immortal)
            {
                Functions.DestroyWithDeathEffects(gameObject, deathCause: DeathCause.Kill);
            }
            dead = true;
        }
        HP = HP > maxHP ? maxHP : HP;

        if (HP > 0 && dead)
        {
            dead = false;
            
        }

    }


}
