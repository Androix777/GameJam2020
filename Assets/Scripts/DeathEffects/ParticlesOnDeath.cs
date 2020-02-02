using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnDeath : MonoBehaviour, IDeathEffect
{
    [SerializeField] private DeathCause allowedDeathCause;
    public DeathCause AllowedDeathCause { get => allowedDeathCause; set => allowedDeathCause = value; }
    public GameObject psystem;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void ActivateEffect()
    {
        Instantiate(psystem, gameObject.transform.position, Quaternion.identity);
    }
}
