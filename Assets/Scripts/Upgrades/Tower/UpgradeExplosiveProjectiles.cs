using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UpgradeExplosiveProjectiles : MonoBehaviour, IUpgrade
{

    Shooter shooter, shooter2;
    ShootOnDeath shootOnDeath;
    GameObject projectile2;

    void Start()
    {
        shooter = gameObject.GetComponent<Shooter>();
        projectile2 = Instantiate(shooter.projectile, gameObject.transform.position, Quaternion.identity);
        projectile2.transform.parent = shooter.projectile.transform;
        projectile2.transform.localScale = shooter.projectile.transform.localScale;
        shooter2 = shooter.projectile.AddComponent<Shooter>();
        shooter2.projectile = projectile2;
        shooter2.numOfGuns = 6;
        shooter2.angleBetweenGuns = 60;
        shooter2.forwardOffset = 0.1f;
        shootOnDeath = shooter.projectile.AddComponent<ShootOnDeath>();
        //shootOnDeath.allowedDeathCause = DeathCause.Сollision;
        shootOnDeath.shooter = shooter2;
    }

    void Update()
    {
        
    }

    void OnDestroy()
    {
        
    }

    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>("icons/" + "i4") as Sprite;
    }
}
