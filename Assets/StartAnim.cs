﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
       GetComponent<Animator>().SetTrigger("Up");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
