using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField]
    float range;

    GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateTarget()
    {
        if (target == null && Vector2.Distance((Vector2)target.transform.position,(Vector2)transform.position) > range)
        {

        }
    }
}
