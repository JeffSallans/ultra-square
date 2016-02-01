using UnityEngine;
using System.Collections;
using System;
using XboxCtrlrInput;

/// <summary>
/// Returns the player input for someone using a controller
/// 
/// ASSUMES: XboxCtrlrInput package is imported (https://github.com/JISyed/Unity-XboxCtrlrInput)
/// </summary>
[System.Serializable]
public class ControllerPlayerInput : PlayerInput
{
    public int controllerNumber;

    /// <summary>
    /// Register the controller as player input
    /// </summary>
    /// <param name="_controllerNumber">Number of the controller to recieve input from</param>
    public ControllerPlayerInput(int _controllerNumber)
    {
        controllerNumber = _controllerNumber;
    }

    public string getName()
    {
        return "Controller Player " + controllerNumber;
    }

    public bool getActionHold()
    {
        return XCI.GetButton(XboxButton.A, controllerNumber);
    }

    public bool getActionPressDown()
    {
        return XCI.GetButtonDown(XboxButton.A, controllerNumber);
    }

    public float getHorizontalAxis()
    {
        return XCI.GetAxis(XboxAxis.LeftStickX, controllerNumber);
    }

    public float getVerticalAxis()
    {
        return XCI.GetAxis(XboxAxis.LeftStickY, controllerNumber);
    }

    public bool getSecondaryActionPressDown()
    {
        return XCI.GetButtonDown(XboxButton.B, controllerNumber);
    }

    public bool getSecondaryActionHold()
    {
        return XCI.GetButton(XboxButton.B, controllerNumber);
    }
}
