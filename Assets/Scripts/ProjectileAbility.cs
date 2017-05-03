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
            currentActivationRate = activationRate;
        }
    }
    public override void UpdateAbility()
    {
        base.UpdateAbility();
        if(currentActivationRate > 0)
        {
            currentActivationRate -= Time.deltaTime;
        }
        canActivate = currentActivationRate <= 0;
    }
}
