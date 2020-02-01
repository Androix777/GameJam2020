using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public static float energyMax = 100;

    private static float energy = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetEnergy(float en)
    {
        energy = Mathf.Clamp(en, 0, energyMax);
    }
    public static float GetEnergy()
    {
        return energy;
    }
}
