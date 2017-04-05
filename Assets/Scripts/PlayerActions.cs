using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class PlayerActions : PlayerActionSet
{
    public PlayerAction jump;
    public PlayerAction shoot;
    public PlayerAction attack;
    public PlayerAction dash;

    public PlayerOneAxisAction move;
    public PlayerAction moveLeft;
    public PlayerAction moveRight;

    public PlayerActions()
    {
        jump = CreatePlayerAction("Jump");
        shoot = CreatePlayerAction("Shoot");
        attack = CreatePlayerAction("Attack");
        dash = CreatePlayerAction("Dash");

        moveLeft = CreatePlayerAction("Move Left");
        moveRight = CreatePlayerAction("Move Right");
        move = CreateOneAxisPlayerAction(moveLeft, moveRight);
    }

    public static PlayerActions BindAll()
    {
        PlayerActions actions = new PlayerActions();

        actions.jump.AddDefaultBinding(Key.Space);
        actions.shoot.AddDefaultBinding(Key.RightControl);
        actions.attack.AddDefaultBinding(Key.E);
        actions.dash.AddDefaultBinding(Key.LeftShift);
        actions.moveLeft.AddDefaultBinding(Key.A);
        actions.moveRight.AddDefaultBinding(Key.D);

        actions.jump.AddDefaultBinding(InputControlType.Action1);
        actions.shoot.AddDefaultBinding(InputControlType.RightTrigger);
        actions.attack.AddDefaultBinding(InputControlType.LeftTrigger);
        actions.dash.AddDefaultBinding(InputControlType.Action4);
        actions.moveLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
        actions.moveRight.AddDefaultBinding(InputControlType.LeftStickRight);

        return actions;
    }
}
