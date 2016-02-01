using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public enum KeyboardPlayerType
{
    WASD,
    ARROW
}

/// <summary>
/// Returns the player input for someone using a keyboard
/// 
/// ASSUMES: The axis names are setup in Unity input config
/// </summary>
[System.Serializable]
public class KeyboardPlayerInput : PlayerInput
{
    //Define the name of the horizontal axis
    Dictionary<KeyboardPlayerType, string> horizontalAxisName = new Dictionary<KeyboardPlayerType, string>
    {
        { KeyboardPlayerType.ARROW, "arrowHorizontal" },
        { KeyboardPlayerType.WASD, "wasdHorizontal" }
    };

    //Define the name of the vertical axis
    Dictionary<KeyboardPlayerType, string> verticalAxisName = new Dictionary<KeyboardPlayerType, string>
    {
        { KeyboardPlayerType.ARROW, "arrowVertical" },
        { KeyboardPlayerType.WASD, "wasdVertical" }
    };

    //Define the name of the action button
    Dictionary<KeyboardPlayerType, string> actionButtonName = new Dictionary<KeyboardPlayerType, string>
    {
        { KeyboardPlayerType.ARROW, "arrowAction" },
        { KeyboardPlayerType.WASD, "wasdAction" }
    };

    //Determines where to get the input from
    public KeyboardPlayerType playerType;

    /// <summary>
    /// Register the keyboard as player input
    /// </summary>
    /// <param name="_playerType">
    /// Which keyboard buttons to register WASD uses W, A, S, and D buttons.  
    /// ARROW uses right, left, down, and up buttons
    /// </param>
    public KeyboardPlayerInput(KeyboardPlayerType _playerType)
    {
        playerType = _playerType;
    }

    public string getName()
    {
        return "Keyboard Player " + playerType.ToString();
    }

    public bool getActionHold()
    {
        return Input.GetButton(actionButtonName[playerType]);
    }

    public bool getActionPressDown()
    {
        return Input.GetButtonDown(actionButtonName[playerType]);
    }

    public float getHorizontalAxis()
    {
        return Input.GetAxis(horizontalAxisName[playerType]);
    }

    public float getVerticalAxis()
    {
        return Input.GetAxis(verticalAxisName[playerType]);
    }

    public bool getSecondaryActionPressDown()
    {
        throw new NotImplementedException();
    }

    public bool getSecondaryActionHold()
    {
        throw new NotImplementedException();
    }
}
