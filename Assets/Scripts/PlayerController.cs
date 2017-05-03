using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InputBus
{
    private PlayerActions controller;

    void Awake()
    {
        controller = PlayerActions.BindAll();
        input = new InputSource();
    }
    void Update()
    {
        Vector3 moveVect = new Vector3(Mathf.RoundToInt(controller.move.Value), 0, 0);
        input.SetAxis("Move", moveVect);
        input.SetButton("Jump", controller.jump.WasPressed);
        input.SetButton("Shoot", controller.shoot.IsPressed);
        input.SetButton("Melee", controller.melee.WasPressed);
        UpdateActions(input);
    }
    
}
