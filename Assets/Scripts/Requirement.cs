using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement : ScriptableObject
{
    public virtual bool Check(InputBus toCheck)
    {
        return false;
    }
}
