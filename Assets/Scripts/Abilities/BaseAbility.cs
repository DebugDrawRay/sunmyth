using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : ScriptableObject
{
    [Header("Activation")]
    public float activationRate;
    protected float currentActivationRate;
    protected bool canActivate;

    public virtual void Execute(AbilityParameters parameters) { }
    public virtual void UpdateAbility(AbilityParameters parameters = null)
    {
        UpdateActivationRate();
    }

    public void UpdateActivationRate()
    {
        if (currentActivationRate > 0)
        {
            currentActivationRate -= Time.deltaTime;
        }
        canActivate = currentActivationRate <= 0;
    }
    public class AbilityParameters
    {
        public Transform origin;
        public Vector3 heldDirection;
        public bool heldButton;
    }
}
