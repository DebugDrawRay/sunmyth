﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBus : MonoBehaviour
{
    protected InputSource input;
    public delegate void ActionContainer(InputSource input);
    private ActionContainer Actions;
    private ActionContainer PhysicsActions;

    public enum State
    {
        None,
        AcceptInput,
        Pause
    }
    public State currentState;

    private StatusController status
    {
        get
        {
            return GetComponent<StatusController>();
        }
    }

    public void Subscribe(ActionContainer action)
    {
        Actions += action;
    }
    public void Unsubscribe(ActionContainer action)
    {
        Actions -= action;
    }
    protected void UpdateActions(InputSource input)
    {
        if(Actions != null)
        {
            Actions(input);
        }
    }

    public void SubscribePhysics(ActionContainer action)
    {
        PhysicsActions += action;
    }
    public void UnsubscribePhysics(ActionContainer action)
    {
        PhysicsActions -= action;
    }
    protected void UpdatePhysicsActions(InputSource input)
    {
        if (PhysicsActions != null)
        {
            PhysicsActions(input);
        }
    }

    protected virtual void Awake()
    {
        if (status)
        {
            status.SubscribeOnHealthZero(Kill);
        }
    }

    protected virtual void Kill()
    {
        Destroy(gameObject);
    }

    public void ChangeState(State newState)
    {
        currentState = newState;
    }
}

public class InputSource
{
    public Dictionary<string, Vector3> axisActions = new Dictionary<string, Vector3>();
    public Dictionary<string, bool> buttonActions = new Dictionary<string, bool>();

    public void SetAxis(string axis, Vector3 input)
    {
        if (axisActions.ContainsKey(axis))
        {
            axisActions[axis] = input;
        }
        else
        {
            axisActions.Add(axis, input);
        }
    }

    public void SetButton(string button, bool input)
    {
        if (buttonActions.ContainsKey(button))
        {
            buttonActions[button] = input;
        }
        else
        {
            buttonActions.Add(button, input);
        }
    }

    public Vector3 GetAxis(string axis)
    {
        if (axisActions.ContainsKey(axis))
        {
            return axisActions[axis];
        }
        else
        {
            Debug.LogWarning(axis + " Not Found");
            return Vector3.zero;
        }
    }

    public bool GetButton(string button)
    {
        if (buttonActions.ContainsKey(button))
        {
            return buttonActions[button];
        }
        else
        {
            Debug.LogWarning(button + " Not Found");
            return false;
        }
    }
}
