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
            if (fixedUpdate)
            {
                GetComponent<InputBus>().SubscribePhysics(Action);
            }
            else
            {
                GetComponent<InputBus>().Subscribe(Action);
            }
        }
    }
    protected virtual void OnDestroy()
    {
        if (fixedUpdate)
        {
            GetComponent<InputBus>().UnsubscribePhysics(Action);
        }
        else
        {
            GetComponent<InputBus>().Unsubscribe(Action);
        }
    }
    protected virtual void Action(InputSource input) { }
}
