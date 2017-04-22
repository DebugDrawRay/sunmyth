using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : BaseAbility
{
    public GameObject projectile;
    public float fireRate;
    private float currentTimeToFire;
    private bool canFire;

    public override void Execute(AbilityParameters parameters)
    {
        base.Execute(parameters);
        if (canFire)
        {
            //Quaternion rot = Quaternion.LookRotation(parameters.origin.right, parameters.origin.right);
            GameObject newProj = Instantiate(projectile, parameters.origin.position, Quaternion.identity);
            newProj.transform.right = parameters.origin.right;
            currentTimeToFire = fireRate;
        }
    }
    public override void UpdateAbility()
    {
        base.UpdateAbility();
        if(currentTimeToFire > 0)
        {
            currentTimeToFire -= Time.deltaTime;
        }
        canFire = currentTimeToFire <= 0;
    }
}
