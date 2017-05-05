using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpController : ActionController
{
    [Header("Properties")]
    public string jumpBinding = "Jump";

    public float shortJumpLength;
    public float midJumpLength;
    public float fullJumpLength;

    public float jumpStrength;

    private bool jumping;
    private Rigidbody rigid;

    [Header("Grounding")]
    public LayerMask groundLayers;
    public float groundRayLength;
    private bool grounded
    {
        get
        {
            Ray groundRay = new Ray(transform.position, -transform.up);
            return Physics.Raycast(groundRay, groundRayLength, groundLayers);
        }
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(grounded && jumping)
        {
            jumping = false;
        }
    }

    protected override void Action(InputSource input)
    {
        if(input.GetButton(jumpBinding) && grounded)
        {
            rigid.AddForce(transform.up * jumpStrength);
            jumping = true;
        }
    }
}
