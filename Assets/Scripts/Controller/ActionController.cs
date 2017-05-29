using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public bool fixedUpdate = false;

    protected virtual void Awake()
    {
        if(GetComponent<InputBus>())
        {
            GetComponent<InputBus>().SubscribePhysics(FixedAction);
            GetComponent<InputBus>().Subscribe(Action);
        }
    }
    protected virtual void OnDestroy()
    {
        if (GetComponent<InputBus>())
        {
            GetComponent<InputBus>().UnsubscribePhysics(FixedAction);
            GetComponent<InputBus>().Unsubscribe(Action);
        }
    }
    protected virtual void Action(InputSource input) { }
    protected virtual void FixedAction(InputSource input) { }
}
