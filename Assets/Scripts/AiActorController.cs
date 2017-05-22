using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiActorController : InputBus
{
    public ScriptedAction[] availableActions;
    private ScriptedAction currentAction;

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
                currentAction = AssessActions();
                if(currentAction != null)
                {
                    currentState = State.PerformAction;
                }
                break;
            case State.MoveTo:
                break;
            case State.PerformAction:
                currentAction.Execute(OnActionComplete, this);
                break;
        }
    }

    public void OnActionComplete()
    {
        
        currentState = State.Idle;
    }
    public ScriptedAction AssessActions()
    {
        ScriptedAction validAction = null;
        foreach(ScriptedAction action in availableActions)
        {
            if(action.HasRequirements(this) && (validAction == null || validAction.cost < action.cost))
            {
                validAction = action;
            }
        }
        return validAction;
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
