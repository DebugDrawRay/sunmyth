using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : BaseAbility
{
    public GameObject projectile;

    public override void Execute(AbilityParameters parameters)
    {
        base.Execute(parameters);
        if (canActivate)
        {
            GameObject newProj = Instantiate(projectile, parameters.origin.position, Quaternion.identity);
            newProj.transform.right = parameters.origin.right;
            newProj.layer = parameters.origin.gameObject.layer;
            currentActivationRate = activationRate;
        }
    }
}
