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

    Stack<IUpgrade> upgrades = new Stack<IUpgrade>();
    public GameObject Anim, particAdd, particLoss;
    GameObject lastAnim;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddUpgrade() 
    {
        IUpgrade component;
        if(entityType == EntityType.Tower)
        {
            String upgr = towerUpgrades[UnityEngine.Random.Range(0, towerUpgrades.Count)];
            component = gameObject.AddComponent(Type.GetType(upgr)) as IUpgrade;
            upgrades.Push(component);
            lastAnim = Instantiate(Anim, gameObject.transform.position, Quaternion.identity);
            lastAnim.transform.Find("i1").GetComponent<SpriteRenderer>().sprite = component.GetIcon();
            Instantiate(particAdd, gameObject.transform.position, Quaternion.identity);
        }
        else if(entityType == EntityType.Wall)
        {
            String upgr = shieldUpgrades[UnityEngine.Random.Range(0, shieldUpgrades.Count)];
            component = gameObject.AddComponent(Type.GetType(upgr)) as IUpgrade;
            upgrades.Push(component);
            lastAnim = Instantiate(Anim, gameObject.transform.position, Quaternion.identity);
            lastAnim.transform.Find("i1").GetComponent<SpriteRenderer>().sprite = component.GetIcon();
            Instantiate(particAdd, gameObject.transform.position, Quaternion.identity);
        }
        else if(entityType == EntityType.Generator)
        {
            String upgr = generatorUpgrades[UnityEngine.Random.Range(0, generatorUpgrades.Count)];
            component = gameObject.AddComponent(Type.GetType(upgr)) as IUpgrade;
            upgrades.Push(component);
            lastAnim = Instantiate(Anim, gameObject.transform.position, Quaternion.identity);
            lastAnim.transform.Find("i1").GetComponent<SpriteRenderer>().sprite = component.GetIcon();
            Instantiate(particAdd, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void RemoveUpgrade() 
    {
        if (upgrades.Count > 0) Destroy(upgrades.Pop() as Component);
        Instantiate(particLoss, gameObject.transform.position, Quaternion.identity);
    }
}
