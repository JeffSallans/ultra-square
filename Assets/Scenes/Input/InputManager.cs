using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ASSUMES this class is added to an object called InputManager
/// </summary>
public class InputManager : MonoBehaviour {

    public const int MAX_NUMBER_OF_PLAYERS = 4;
    public const string OBJECT_NAME = "InputManager";

    public Dictionary<int, PlayerInput> playerControls;

    /// <summary>
    /// Inspector variables to show state.  Warning this is not nessary accurate.
    /// </summary>
    public List<string> playerControlsName;

    // Use this for initialization
    void Start () {
        playerControls = new Dictionary<int, PlayerInput>();
        playerControlsName = new List<string>();

        //Keep state over multiple screens
        DontDestroyOnLoad(gameObject);

        //If another Input Manager is detected, remove it
        gameObject.name = "NEW_" + OBJECT_NAME;
        var oldInputManagerObject = GameObject.Find(OBJECT_NAME);
        Destroy(oldInputManagerObject);

        //Assign name
        gameObject.name = OBJECT_NAME;
    }

    /// <summary>
    /// Adds the provided input to playerControls at the given location
    /// 
    /// MODIFIES: playerControls
    /// </summary>
    /// <param name="playerInput">input to add to playerControls</param>
    public void assignPlayerInput(PlayerInput playerInput)
    {
        //Do not add if max is already met
        if (playerControls.Count == MAX_NUMBER_OF_PLAYERS) return;

        var nextPlayerIndex = playerControls.Count;

        playerControls.Add(nextPlayerIndex, playerInput);

        //Update string display accordingly
        playerControlsName.Add(playerInput.getName());
    }

    /// <summary>
    /// Returns the current input manager if it exists
    /// </summary>
    /// <returns></returns>
    public static InputManager getCurrentInputManager()
    {
        return GameObject.Find(InputManager.OBJECT_NAME).GetComponent<InputManager>();
    }
}
