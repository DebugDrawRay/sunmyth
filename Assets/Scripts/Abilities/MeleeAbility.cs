using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbility : BaseAbility
{
    public GameObject weapon;
    public Vector3 weaponOffset;

    public override void Execute(AbilityParameters parameters)
    {
        base.Execute(parameters);
        if (canActivate && parameters.heldButton)
        {
            Vector3 calcOffset = parameters.origin.position + (Mathf.Sign(parameters.origin.right.x) * weaponOffset);
            GameObject newProj = Instantiate(weapon, calcOffset, Quaternion.identity, parameters.origin);
            currentActivationRate = activationRate;
        }
    }
}
