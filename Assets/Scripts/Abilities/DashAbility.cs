using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DashAbility : BaseAbility
{
    [Space(10)]
    [Header("Targeting")]
    public LayerMask validTargetLayers;
    public string priorityTargetTag;
    [Space(10)]
    [Header("Parameters")]
    public float maxDashDistance;
    public float dashTime;
    private bool canDash = true;
    private Tween dashTween;
    [Space(5)]
    public AnimationCurve dashEase;
    [Space(5)]
    public float floatTime;
    private float currentFloatTime;
    [Space(10)]
    [Header("Grounding")]
    public LayerMask groundLayers;
    public float groundRayLength;

    public override void Execute(AbilityParameters parameters)
    {
        base.Execute(parameters);
        if(canActivate && parameters.heldButton)
        {
            Collider[] targets = Physics.OverlapSphere(parameters.origin.position, maxDashDistance, validTargetLayers);

            if(targets.Length > 0)
            {
                GameObject dashTarget = null;
                float shortDist = maxDashDistance;
                foreach (Collider target in targets)
                {
                    float targetDist = Vector3.Distance(parameters.origin.position, target.transform.position);

                    float facing = Mathf.Sign(parameters.origin.right.x);
                    float dir = Mathf.Sign((target.transform.position - parameters.origin.position).x);
                    if (targetDist <= shortDist && facing == dir)
                    {
                        shortDist = Vector3.Distance(parameters.origin.position, target.transform.position);
                        dashTarget = target.gameObject;
                    }
                }
                if (dashTarget)
                {
                    DashTowards(parameters.origin, dashTarget.transform.position);
                }
                else
                {
                    Vector3 location = parameters.origin.position + (parameters.heldDirection * maxDashDistance);
                    Dash(parameters.origin, location);
                }
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
        if (canDash)
        {
            isRunning = true;
            if (dashTween != null)
            {
                dashTween.Kill();
            }
            canDash = false;
            dashTween = target.GetComponent<Rigidbody>().DOMove(to, dashTime).SetEase(dashEase).OnComplete(() => isRunning = false);
            currentActivationRate = activationRate;
        }
    }
    void DashTowards(Transform target, Vector3 to)
    {
        isRunning = true;
        if (dashTween != null)
        {
            dashTween.Kill();
        }
        currentFloatTime = 0;
        dashTween = target.GetComponent<Rigidbody>().DOMove(to, dashTime).SetEase(dashEase).OnComplete(CompleteTargetDash);
        currentActivationRate = activationRate;
    }

    public override void UpdateAbility(AbilityParameters parameters = null)
    {
        base.UpdateAbility(parameters);

        if (currentFloatTime > 0)
        {
            parameters.origin.GetComponent<Rigidbody>().velocity = Vector3.zero;
            currentFloatTime -= Time.deltaTime;
        }
        parameters.origin.GetComponent<ConstantForce>().enabled = currentFloatTime <= 0;
        parameters.origin.GetComponent<Rigidbody>().isKinematic = currentFloatTime > 0;

        if (!canDash)
        {
            Ray groundRay = new Ray(parameters.origin.position, -parameters.origin.up);
            canDash = Physics.Raycast(groundRay, groundRayLength, groundLayers);
        }

        Debug.Log(dashTween == null);
    }

    void CompleteTargetDash()
    {
        isRunning = false;
        currentFloatTime = floatTime;
    }
}
