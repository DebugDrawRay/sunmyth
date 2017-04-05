using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    protected virtual void Awake()
    {
        if(GetComponent<InputBus>())
        {
            GetComponent<InputBus>().Subscribe(Action);
        }
    }
    protected virtual void OnDestroy()
    {
        if (GetComponent<InputBus>())
        {
            GetComponent<InputBus>().Unsubscribe(Action);
        }
    }
    protected virtual void Action(InputSource input) { }
}
