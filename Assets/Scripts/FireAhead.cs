using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAhead : ScriptedAction
{

    [Header("Movement Properties")]
    public float targetRange = 1.5f;
    public string moveInput;

    protected override bool CheckPrerequirements(InputBus actionTarget)
    {
        return FindTarget(actionTarget).isTriggered;
    }

    public override void Execute(ActionCallback Callback, InputBus actionTarget)
    {
        Transform target = FindTarget(actionTarget).positionData;

        Vector3 axis = new Vector3(1, 0, 0);

        if (target.position.x < actionTarget.transform.position.x)
        {
            axis = -axis;
        }
        Debug.Log(axis);
        ((AiActorController)actionTarget).UpdateInput(moveInput, axis);

        if (Vector3.Distance(actionTarget.transform.position, target.position) < targetRange)
        {
            ((AiActorController)actionTarget).UpdateInput(moveInput, Vector3.zero);
            Callback();
        }
    }
}
