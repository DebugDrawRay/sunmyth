using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : ScriptableObject
{
    public virtual void Execute(AbilityParameters parameters) { }
    public virtual void UpdateAbility() { }

    public class AbilityParameters
    {
        public Transform origin;
    }
}
