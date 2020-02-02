using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamage : MonoBehaviour, IUpgrade
{

    public int damageBonus = 5;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Shooter>().projectile.GetComponent<DamageDealer>().damage += damageBonus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        gameObject.GetComponent<Shooter>().projectile.GetComponent<DamageDealer>().damage -= damageBonus;
    }

    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>("icons/" + "i8.npg") as Sprite;
    }
}
