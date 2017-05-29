using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : ActionController
{
    public string directionInput = "Move";
    [System.Serializable]
    public class AbilityContainer
    {
        public string controlName;
        public enum Type
        {
            Button,
            Axis
        }
        public Type controlType;
        public bool fixedUpdate;
        public BaseAbility ability;
    }
    public AbilityContainer[] availableAbilities;

    void Update()
    {
        foreach(AbilityContainer container in availableAbilities)
        {
            BaseAbility.AbilityParameters param = new BaseAbility.AbilityParameters();
            param.origin = transform;
            container.ability.UpdateAbility(param);
        }
    }

    protected override void Action(InputSource input)
    {
        base.Action(input);
        BaseAbility.AbilityParameters param = new BaseAbility.AbilityParameters();
        param.origin = transform;

        foreach (AbilityContainer container in availableAbilities)
        {
            if (!container.fixedUpdate)
            {
                switch (container.controlType)
                {
                    case AbilityContainer.Type.Axis:
                        param.heldDirection = input.GetAxis(container.controlName);
                        container.ability.Execute(param);
                        break;
                    case AbilityContainer.Type.Button:
                        param.heldDirection = input.GetAxis(directionInput);
                        param.heldButton = input.GetButton(container.controlName);
                        container.ability.Execute(param);
                        break;
                }
            }
        }
    }

    protected override void FixedAction(InputSource input)
    {
        base.Action(input);
        BaseAbility.AbilityParameters param = new BaseAbility.AbilityParameters();
        param.origin = transform;

        foreach (AbilityContainer container in availableAbilities)
        {
            if (container.fixedUpdate)
            {
                switch (container.controlType)
                {
                    case AbilityContainer.Type.Axis:
                        param.heldDirection = input.GetAxis(container.controlName);
                        container.ability.Execute(param);
                        break;
                    case AbilityContainer.Type.Button:
                        param.heldDirection = input.GetAxis(directionInput);
                        param.heldButton = input.GetButton(container.controlName);
                        container.ability.Execute(param);
                        break;
                }
            }
        }
    }
}
