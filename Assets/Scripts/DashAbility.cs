using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DashAbility : BaseAbility
{
    public LayerMask validTargetLayers;
    public string priorityTargetTag;
    public float maxDashDistance;
    public float dashTargetingOffset;
    public float dashTime;
    public AnimationCurve dashTween;

    public float floatTime;
    private float currentFloatTime;

    public override void Execute(AbilityParameters parameters)
    {
        base.Execute(parameters);
        if(canActivate)
        {
            Ray targeting = new Ray(parameters.origin.position, parameters.heldDirection);
            RaycastHit[] targets = Physics.SphereCastAll(targeting, dashTargetingOffset, maxDashDistance, validTargetLayers);

            if(targets.Length > 0)
            {
                GameObject dashTarget = null;
                float distance = maxDashDistance;
                foreach(RaycastHit target in targets)
                {
                    if(Vector3.Distance(parameters.origin.position, target.transform.position) <= distance)
                    {
                        distance = Vector3.Distance(parameters.origin.position, target.transform.position);
                        dashTarget = target.collider.gameObject;
                    }
                }
                Dash(parameters.origin, dashTarget.transform.position);
            }
            else
            {
                Vector3 location = parameters.origin.position + (parameters.heldDirection * maxDashDistance);
                Dash(parameters.origin, location);
            }
        }
    }

    void Dash(Transform target, Vector3 to)
    {
        target.DOMove(to, dashTime).SetEase(dashTween);
        currentActivationRate = activationRate;
        currentFloatTime = floatTime;
    }

    public override void UpdateAbility(AbilityParameters parameters = null)
    {
        base.UpdateAbility(parameters);
        parameters.origin.GetComponent<ConstantForce>().enabled = currentFloatTime <= 0;

        if (currentFloatTime > 0)
        {
            parameters.origin.GetComponent<Rigidbody>().Sleep();
            currentFloatTime -= Time.deltaTime;
        }

    }
    IEnumerator DashAction(Transform target, Vector3 to)
    {
        float elapsedTime = 0;
        Vector3 start = target.position;
        while(elapsedTime < dashTime)
        {
            float currentCompletion = dashTween.Evaluate(elapsedTime / dashTime);
            target.position = Vector3.Lerp(start, to, currentCompletion);
            yield return null;
        }
    }
}
