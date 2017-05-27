using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedAction : ScriptableObject
{
    [Header("Properties")]
    public int cost;
    public Requirement[] requirements;
    [Header("Targeting")]
    public bool useVision;
    public float trackingDistance;

    public LayerMask visionLayers;
    public LayerMask nonVisionLayers;

    public string targetTag = "Player";
    private GameObject[] targets
    {
        get
        {
            return GameObject.FindGameObjectsWithTag(targetTag);
        }
    }

    public delegate void ActionCallback();
    protected bool CheckRequirements(InputBus actionTarget)
    {
        foreach(Requirement requirement in requirements)
        {
            if(!requirement.Check(actionTarget))
            {
                return false;
            }
        }
        return true;
    }
    protected virtual bool CheckPrerequirements(InputBus actionTarget)
    {
        return false;
    }
    public bool HasRequirements(InputBus actionTarget)
    {
        if(CheckPrerequirements(actionTarget) && CheckRequirements(actionTarget))
        {
            return true;
        }
        return false;
    }
    public virtual void Execute(ActionCallback Callback, InputBus actionTarget)
    {

    }

    //Common functions

    protected RelayData FindTarget(InputBus observer)
    {
        RelayData data = new RelayData();
        LayerMask mask = nonVisionLayers;
        if (useVision)
        {
            mask = visionLayers;
        }

        //vvv Fucking change this vvv
        if (targets.Length > 0)
        {
            GameObject target = targets[0];
            Vector3 targetDir = target.transform.position - observer.transform.position;
            Ray targeting = new Ray(observer.transform.position, targetDir);

            data.isTriggered = Physics.Raycast(targeting, trackingDistance, mask);
            data.positionData = target.transform;
        }
        return data;
    }
}
