using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAction : ScriptedAction
{
    [Header("Action Properties")]
    public float vaildActionRange = 5f;
    public string actionInput;
    [Header("Movement Properties")]
    public string moveInput;
    public bool alwaysFaceTarget = true;
    public bool followTarget = false;
    public bool followWithinRange;

    protected override bool CheckPrerequirements(InputBus actionTarget)
    {
        Transform target = FindTarget(actionTarget).positionData;
        bool within = Vector3.Distance(actionTarget.transform.position, target.position) < vaildActionRange;
        bool found = FindTarget(actionTarget).isTriggered;
        return within && found;
    }

    public override void Execute(ActionCallback Callback, InputBus actionTarget)
    {
        Transform target = FindTarget(actionTarget).positionData;
        ((AiActorController)actionTarget).UpdateInput(actionInput, true);

        float facing = Mathf.Sign(actionTarget.transform.right.x);
        float dir = Mathf.Sign((target.transform.position - actionTarget.transform.position).x);
        if (alwaysFaceTarget && facing != dir)
        {
            actionTarget.transform.right = -actionTarget.transform.right;
        }

        if (Vector3.Distance(actionTarget.transform.position, target.position) > vaildActionRange)
        {
            ((AiActorController)actionTarget).UpdateInput(actionInput, false);
            Callback();
        }
    }
}
