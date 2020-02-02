﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAbsorb : MonoBehaviour, IUpgrade
{
    public Sprite icon { get; set; } = Resources.Load<Sprite>("icons/" + "i11.npg") as Sprite;
    [SerializeField]
    float absorb = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Life>().absorpdProc += absorb;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        GetComponent<Life>().absorpdProc -= absorb;
    }
}
