using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFireRate : MonoBehaviour, IUpgrade
{
    public Sprite icon { get; set; }
    public float rateAmount = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Shooter>().fireRate -= rateAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        gameObject.GetComponent<Shooter>().fireRate += rateAmount;
    }
}
