using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UpgradeDamage : MonoBehaviour
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
}
