using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelfDamage : MonoBehaviour, IUpgrade
{

    public int damageAmount = -1;
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

    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>("icons/" + "i8") as Sprite;
    }
}
