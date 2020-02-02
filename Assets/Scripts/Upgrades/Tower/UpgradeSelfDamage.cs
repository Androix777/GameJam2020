using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelfDamage : MonoBehaviour
{
    public int damageAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Shooter>().damagePerShoot += damageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        gameObject.GetComponent<Shooter>().damagePerShoot -= damageAmount;
    }
}
