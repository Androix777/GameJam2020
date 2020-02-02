using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeReflect : MonoBehaviour, IUpgrade
{
    public Sprite icon { get; set; } = Resources.Load<Sprite>("icons/" + "i6.npg") as Sprite;

    public int reflectChance = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
