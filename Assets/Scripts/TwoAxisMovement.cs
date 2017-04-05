using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class TwoAxisMovement : ActionController
{
    public string moveBinding = "Move";
    public float maxSpeed = 1;
    [Tooltip("Time to max/zero speed")]
    public float moveAccel = .1f;

    private Vector3 lastDirection;
    private float currentSpeed;
    private Rigidbody rigid;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("This");
        rigid = GetComponent<Rigidbody>();
    }
    protected override void Action(InputSource input)
    {
        if (input.GetAxis(moveBinding) == Vector3.zero && currentSpeed > 0)
        {
            currentSpeed -= moveAccel;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, Mathf.Infinity);
        }
        else
        {
            currentSpeed += moveAccel;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
            lastDirection = input.GetAxis(moveBinding);
        }
        Vector3 movement = lastDirection * currentSpeed * Time.deltaTime;
        rigid.MovePosition(transform.position + movement);

    }
}
