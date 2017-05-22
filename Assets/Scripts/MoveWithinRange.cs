using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithinRange : ScriptedAction
{
    [Header("Movement Properties")]
    public float targetRange = 1.5f;
    public string moveInput;

    protected override bool CheckPrerequirements(InputBus actionTarget)
    {
        Transform target = FindTarget(actionTarget).positionData;
        bool within = Vector3.Distance(actionTarget.transform.position, target.position) > targetRange;
        bool found = FindTarget(actionTarget).isTriggered;
        return within && found;
    }

    public override void Execute(ActionCallback Callback, InputBus actionTarget)
    {
        Transform target = FindTarget(actionTarget).positionData;

        Vector3 axis = new Vector3(1, 0, 0);

        if(target.position.x < actionTarget.transform.position.x)
        {
            axis = -axis;
        }
        ((AiActorController)actionTarget).UpdateInput(moveInput, axis);

        if (Vector3.Distance(actionTarget.transform.position, target.position) < targetRange)
        {
            ((AiActorController)actionTarget).UpdateInput(moveInput, Vector3.zero);
            Callback();
        }
    }
}
