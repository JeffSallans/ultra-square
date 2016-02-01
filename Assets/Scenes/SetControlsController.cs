using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SetControlsController : MonoBehaviour
{

    public InputManager inputManager;

    public List<PlayerInput> unregisteredInputs;

    /// <summary>
    /// Inspector variables to show state.  Warning this is not nessary accurate.
    /// </summary>
    public List<string> unregisteredInputsName;

    // Use this for initialization
    void Start()
    {
        unregisteredInputs = new List<PlayerInput>();
        unregisteredInputsName = new List<string>();

        //Init keyboard input
        unregisteredInputs.Add(new KeyboardPlayerInput(KeyboardPlayerType.WASD));
        unregisteredInputs.Add(new KeyboardPlayerInput(KeyboardPlayerType.ARROW));

        //Init controller input
        unregisteredInputs.Add(new ControllerPlayerInput(1));
        unregisteredInputs.Add(new ControllerPlayerInput(2));
        unregisteredInputs.Add(new ControllerPlayerInput(3));
        unregisteredInputs.Add(new ControllerPlayerInput(4));

        //Update the unregistered Name list
        unregisteredInputs.ForEach(input =>
        {
            unregisteredInputsName.Add(input.getName());
        });
    }

    // Update is called once per frame
    void Update()
    {
        inputManager = InputManager.getCurrentInputManager();

        //Do not search for input if max players are registered
        if (inputManager.playerControls.Count == InputManager.MAX_NUMBER_OF_PLAYERS)
        {
            return;
        }

        //Loop over each unregistered input and check if a button is pressed
        unregisteredInputs.ForEach(input =>
        {
            if (input.getActionPressDown() ||
            input.getHorizontalAxis() != 0f ||
            input.getVerticalAxis() != 0f)
            {
                inputManager.assignPlayerInput(input);
            }
        });

        //Remove all player assigned input from unregistered input
        var assignedInputs = inputManager.playerControls.Values.ToList();
        assignedInputs.ForEach(input =>
        {
            unregisteredInputs.Remove(input);
            unregisteredInputsName.Remove(input.getName());
        });
    }


}
