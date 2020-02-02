﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEnergy : MonoBehaviour, IUpgrade
{
    public Sprite icon { get; set; } = Resources.Load<Sprite>("icons/" + "i10.npg") as Sprite;
    public int energyAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Generator>().energy += energyAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        gameObject.GetComponent<Generator>().energy -= energyAmount;
    }
}
