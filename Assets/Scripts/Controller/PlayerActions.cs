using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class PlayerActions : PlayerActionSet
{
    public PlayerAction jump;
    public PlayerAction shoot;
    public PlayerAction melee;
    public PlayerAction dash;

    public PlayerTwoAxisAction move;
    public PlayerAction moveLeft;
    public PlayerAction moveRight;
    public PlayerAction moveUp;
    public PlayerAction moveDown;

    public PlayerActions()
    {
        jump = CreatePlayerAction("Jump");
        shoot = CreatePlayerAction("Shoot");
        melee = CreatePlayerAction("Melee");
        dash = CreatePlayerAction("Dash");

        moveLeft = CreatePlayerAction("Move Left");
        moveRight = CreatePlayerAction("Move Right");
        moveDown = CreatePlayerAction("Move Down");
        moveUp = CreatePlayerAction("Move Up");
        move = CreateTwoAxisPlayerAction(moveLeft, moveRight, moveDown, moveUp);
    }

    public static PlayerActions BindAll()
    {
        PlayerActions actions = new PlayerActions();

        actions.jump.AddDefaultBinding(Key.Space);
        actions.shoot.AddDefaultBinding(Key.RightControl);
        actions.melee.AddDefaultBinding(Key.E);
        actions.dash.AddDefaultBinding(Key.LeftShift);
        actions.moveLeft.AddDefaultBinding(Key.A);
        actions.moveRight.AddDefaultBinding(Key.D);
        actions.moveDown.AddDefaultBinding(Key.S);
        actions.moveUp.AddDefaultBinding(Key.W);

        actions.jump.AddDefaultBinding(InputControlType.Action1);
        actions.shoot.AddDefaultBinding(InputControlType.RightTrigger);
        actions.melee.AddDefaultBinding(InputControlType.LeftTrigger);
        actions.dash.AddDefaultBinding(InputControlType.Action4);
        actions.moveLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
        actions.moveRight.AddDefaultBinding(InputControlType.LeftStickRight);
        actions.moveDown.AddDefaultBinding(InputControlType.LeftStickDown);
        actions.moveUp.AddDefaultBinding(InputControlType.LeftStickUp);

        return actions;
    }
}
