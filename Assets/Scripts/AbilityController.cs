﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : ActionController
{
    [System.Serializable]
    public class AbilityContainer
    {
        public string controlName;
        public BaseAbility ability;
    }
    public AbilityContainer[] availableAbilities;

    void Update()
    {
        foreach(AbilityContainer container in availableAbilities)
        {
            container.ability.UpdateAbility();
        }
    }

    protected override void Action(InputSource input)
    {
        base.Action(input);
        BaseAbility.AbilityParameters param = new BaseAbility.AbilityParameters();
        param.origin = transform;

        foreach (AbilityContainer container in availableAbilities)
        {
            if(input.GetButton(container.controlName))
            {
                container.ability.Execute(param);
            }
        }
    }
}