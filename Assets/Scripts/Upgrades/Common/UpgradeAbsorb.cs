using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAbsorb : MonoBehaviour, IUpgrade
{
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

    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>("icons/" + "i11") as Sprite;
    }
}
