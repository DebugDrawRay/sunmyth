using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InputBus
{
    private PlayerActions controller;

    public static PlayerController instance;


    protected override void Awake()
    {
        base.Awake();

        controller = PlayerActions.BindAll();
        input = new InputSource();

        InitializeInput();
        InitializeInstance();
    }
    void InitializeInput()
    {
        input.SetAxis("Move", Vector3.zero);
        input.SetButton("Jump", false);
        input.SetButton("Shoot", false);
        input.SetButton("Melee", false);
        input.SetButton("Dash", false);
    }
    void InitializeInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    void Update()
    {
        UpdateInput();
        UpdateActions(input);
    }
    void FixedUpdate()
    {
        UpdatePhysicsActions(input);
    }
    void UpdateInput()
    {
        Vector3 moveVect = new Vector3(Mathf.RoundToInt(controller.move.Value), 0, 0);
        input.SetAxis("Move", moveVect);
        input.SetButton("Jump", controller.jump.IsPressed);
        input.SetButton("Shoot", controller.shoot.IsPressed);
        input.SetButton("Melee", controller.melee.WasPressed);
        input.SetButton("Dash", controller.dash.WasPressed);
    }
  
}
