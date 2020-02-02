using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UpgradeNumOfGuns : MonoBehaviour, IUpgrade
{

    Shooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        shooter = gameObject.GetComponent<Shooter>();
        shooter.numOfGuns += 1;
        if (shooter.distanceBetweenGuns == 0) shooter.distanceBetweenGuns = 0.3f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        shooter.numOfGuns -= 1;
    }

    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>("icons/" + "i8") as Sprite;
    }
}
