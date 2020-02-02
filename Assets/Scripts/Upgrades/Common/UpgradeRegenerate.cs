using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRegenerate : MonoBehaviour, IUpgrade
{
    public Sprite icon { get; set; }
    public int regenAmount = 1;
    public float regenRate = 0.5f;
    public float lastRegenTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Life>().HP < gameObject.GetComponent<Life>().maxHP && Time.time - lastRegenTime > regenRate && gameObject.GetComponent<Life>().HP > 0)
        {
            lastRegenTime = Time.time;
            gameObject.GetComponent<Life>().HP += regenAmount;
        }
    }
}
