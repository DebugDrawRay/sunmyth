using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAbility : BaseAbility
{
    [Header("Properties")]
    public float jumpStrength;
    public float jumpFalloff = .5f;

    private bool jumping;
    private float currentJumpStrength;

    private int frames;

    [Header("Grounding")]
    public LayerMask groundLayers;
    public float groundRayLength;

    public override void UpdateAbility(AbilityParameters parameters = null)
    {
        base.UpdateAbility(parameters);
        Ray groundRay = new Ray(parameters.origin.position, -parameters.origin.transform.up);
        if (Physics.Raycast(groundRay, groundRayLength, groundLayers) && jumping)
        {
            jumping = false;
        }
    }

    public override void Execute(AbilityParameters parameters)
    {
        if (parameters.heldButton)
        {
            parameters.origin.GetComponent<Rigidbody>().AddForce(parameters.origin.up * currentJumpStrength, ForceMode.VelocityChange);
            currentJumpStrength -= jumpFalloff;
            if (currentJumpStrength < 0f)
            {
                currentJumpStrength = 0;
            }
        }
        else
        {
            Ray groundRay = new Ray(parameters.origin.position, -parameters.origin.transform.up);
            if (Physics.Raycast(groundRay, groundRayLength, groundLayers))
            {
                currentJumpStrength = jumpStrength;
            }
        }
    }
}
