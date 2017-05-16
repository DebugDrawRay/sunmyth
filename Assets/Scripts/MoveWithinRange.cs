using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithinRange : ScriptedAction
{
    public float targetRange = 1.5f;
    public string moveInput;

    protected override bool CheckPrerequirements(InputBus actionTarget)
    {
        return FindTarget(actionTarget).isTriggered;
    }

    public override void Execute(ActionCallback Callback, InputBus actionTarget)
    {
        Transform target = FindTarget(actionTarget).positionData;
        while(Vector3.Distance(actionTarget.transform.position, target.position) > targetRange)
        {
            Vector3 axis = new Vector3(1, 0, 0);

            Vector3 dir = target.position - actionTarget.transform.position;

            if(dir.x < actionTarget.transform.position.x)
            {
                axis = -axis;
            }
        }
        Callback();
    }
}
