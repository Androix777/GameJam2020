using System;
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

    [SerializeField] 
    public int [] upgradePoints;

    [SerializeField] 
    public int [] upgradeResetPoints;
    public int level = 0;
    public bool upgradable = false;
    Upgrader upgrader;

    void Start()
    {
        upgrader = gameObject.GetComponent<Upgrader>();
        if (upgradable)
        {
            for (int i = upgradePoints.Length-1; i >= 0; i--)
            {
                if (HP >= upgradePoints[i])
                {
                    level = i + 1;
                    for (int j = 0; j <= i; j++) upgrader.AddUpgrade();
                    break;
                }
            }
        }
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

        while (upgradable && level > 0 && HP < upgradeResetPoints[level-1])
        {
            level--;
            upgrader.RemoveUpgrade();
        }

        while (upgradable && level < upgradePoints.Length && HP > upgradePoints[level])
        {
            level++;
            upgrader.AddUpgrade();
        }
    }

}
