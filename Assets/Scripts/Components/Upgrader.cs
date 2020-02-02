using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Upgrader : MonoBehaviour
{
    public EntityType entityType;
    List<string> towerUpgrades = new List<string>() {"UpgradeDamage", "UpgradeFireRate", "UpgradeRegenerate", "UpgradeSelfDamage"};

    Stack<Component> upgrades = new Stack<Component>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddUpgrade() 
    {
        if(entityType == EntityType.Tower)
        {
            String upgr = towerUpgrades[UnityEngine.Random.Range(0, towerUpgrades.Count)];
            Debug.Log(Type.GetType(upgr));
            upgrades.Push(gameObject.AddComponent(Type.GetType(upgr)));
        }
    }

    public void RemoveUpgrade() 
    {
        if (upgrades.Count > 0) Destroy(upgrades.Pop());
    }
}
