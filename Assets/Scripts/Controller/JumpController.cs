using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpController : ActionController
{
    [Header("Properties")]
    public string jumpBinding = "Jump";
    public float jumpStrength;
    public float jumpFalloff = .5f;

    private bool jumping;
    private float currentJumpStrength;
    private Rigidbody rigid;

    private int frames;

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
        currentJumpStrength = jumpStrength;
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
        if (input.GetButton(jumpBinding))
        {
            //rigid.AddForce(transform.up * currentJumpStrength, ForceMode.VelocityChange);
            currentJumpStrength -= jumpFalloff;
            if (currentJumpStrength < 0f)
            {
                currentJumpStrength = 0;
            }
        }
        else
        {
            if (grounded)
            {
                currentJumpStrength = jumpStrength;
            }
        }

        //if(input.GetButton(jumpBinding) && grounded)
        //{
        //    rigid.AddForce(transform.up * jumpStrength);
        //    jumping = true;
        //}
    }
}
