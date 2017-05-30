using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoAxisMoveAbility : BaseAbility
{
    public float maxSpeed = 1;
    public bool trackX = true, trackY = true;
    [Tooltip("Time to max/zero speed")]
    public float moveAccel = .1f;

    private Vector3 lastDirection;
    private float currentSpeed = 10;

    public override void Execute(AbilityParameters parameters)
    {
        Vector3 axisInput = parameters.heldDirection;
        if (!trackX)
        {
            axisInput.x = 0;
        }
        if (!trackY)
        {
            axisInput.y = 0;
        }

        if (axisInput == Vector3.zero)
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= moveAccel;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, Mathf.Infinity);
            }
        }
        else
        {
            currentSpeed += moveAccel;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
            lastDirection = axisInput;
            parameters.origin.right = axisInput;
        }
        isRunning = axisInput != Vector3.zero;
        Vector3 movement = parameters.origin.right * currentSpeed;
        parameters.origin.GetComponent<Rigidbody>().MovePosition(parameters.origin.position + movement * Time.deltaTime);
    }
}
