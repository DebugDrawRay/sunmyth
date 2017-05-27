using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class TwoAxisMovement : ActionController
{
    public string moveBinding = "Move";
    public float maxSpeed = 1;
    public bool trackX = true, trackY = true;
    [Tooltip("Time to max/zero speed")]
    public float moveAccel = .1f;

    private Vector3 lastDirection;
    private float currentSpeed = 10;
    private Rigidbody rigid;

    protected override void Awake()
    {
        base.Awake();
        rigid = GetComponent<Rigidbody>();
    }
    protected override void Action(InputSource input)
    {
        Vector3 axisInput = input.GetAxis(moveBinding);
        if(!trackX)
        {
            axisInput.x = 0;
        }
        if(!trackY)
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
            transform.right = axisInput;
        }
        Vector3 movement = transform.right * currentSpeed;
        rigid.MovePosition(transform.position + movement * Time.deltaTime);
    }
}
