using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiActorController : InputBus
{
    public ScriptedAction[] AvailableActions;
    public enum State
    {
        Idle,
        MoveTo,
        PerformAction
    }
    private State currentState;

    private void Awake()
    {
        input = new InputSource();
    }
    private void Update()
    {
        RunStates();
        UpdateActions(input);
    }
    private void FixedUpdate()
    {
        UpdatePhysicsActions(input);
    }
    void RunStates()
    {
        switch(currentState)
        {
            case State.Idle:
                break;
            case State.MoveTo:
                break;
            case State.PerformAction:
                break;
        }
    }

    public void UpdateInput(string target, Vector3 value)
    {
        input.SetAxis(target, value);
    }
    public void UpdateInput(string target, bool value)
    {
        input.SetButton(target, value);
    }
}
