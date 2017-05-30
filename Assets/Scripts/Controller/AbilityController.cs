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
        public List<string> mutedAbilities;
        [HideInInspector]
        public bool isRunning;
    }
    public AbilityContainer[] availableAbilities;
     
    void Update()
    {
        foreach(AbilityContainer container in availableAbilities)
        {
            BaseAbility.AbilityParameters param = new BaseAbility.AbilityParameters()
            {
                origin = transform
            };
            container.ability.UpdateAbility(param);
        }
    }

    protected override void Action(InputSource input)
    {
        base.Action(input);
        BaseAbility.AbilityParameters param = new BaseAbility.AbilityParameters()
        {
            origin = transform
        };
        foreach (AbilityContainer container in availableAbilities)
        {
            if (!container.fixedUpdate && !CheckMuted(container.controlName))
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
        BaseAbility.AbilityParameters param = new BaseAbility.AbilityParameters()
        {
            origin = transform
        };
        foreach (AbilityContainer container in availableAbilities)
        {
            if (container.fixedUpdate && !CheckMuted(container.controlName))
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

    bool CheckMuted(string controlName)
    {
        BaseAbility.AbilityParameters param = new BaseAbility.AbilityParameters()
        {
            origin = transform
        };
        foreach (AbilityContainer container in availableAbilities)
        {
            if(container.ability.isRunning && container.mutedAbilities.Contains(controlName))
            {
                switch (container.controlType)
                {
                    case AbilityContainer.Type.Axis:
                        param.heldDirection = Vector3.zero;
                        container.ability.Execute(param);
                        break;
                    case AbilityContainer.Type.Button:
                        param.heldDirection = Vector3.zero;
                        param.heldButton = false;
                        container.ability.Execute(param);
                        break;
                }
                return true;
            }
        }
        return false;
    }
    
    void SetIsRunning(AbilityContainer container, bool isRunning)
    {
        container.isRunning = isRunning;
    }
}
