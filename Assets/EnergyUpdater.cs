using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUpdater : MonoBehaviour
{
    Core core;

    void Start()
    {
        core = GameObject.FindWithTag("Core").GetComponent<Core>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Text>().text = Core.GetEnergy().ToString();
    }
}
