using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Upgrader : MonoBehaviour
{
    public EntityType entityType;
    List<string> towerUpgrades = new List<string>() {"UpgradeDamage", "UpgradeFireRate", "UpgradeRegenerate", "UpgradeSelfDamage", "UpgradeExplosiveProjectiles", "UpgradeNumOfGuns"};
    List<string> shieldUpgrades = new List<string>() {"UpgradeReflect", "UpgradeRegenerate", "UpgradeAbsorb"};
    List<string> generatorUpgrades = new List<string>() {"UpgradeEnergy", "UpgradeRegenerate", "UpgradeAbsorb"};

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
        else if(entityType == EntityType.Wall)
        {
            String upgr = shieldUpgrades[UnityEngine.Random.Range(0, shieldUpgrades.Count)];
            Debug.Log(Type.GetType(upgr));
            upgrades.Push(gameObject.AddComponent(Type.GetType(upgr)));
        }
        else if(entityType == EntityType.Generator)
        {
            String upgr = generatorUpgrades[UnityEngine.Random.Range(0, generatorUpgrades.Count)];
            Debug.Log(Type.GetType(upgr));
            upgrades.Push(gameObject.AddComponent(Type.GetType(upgr)));
        }
    }

    public void RemoveUpgrade() 
    {
        if (upgrades.Count > 0) Destroy(upgrades.Pop());
    }
}
