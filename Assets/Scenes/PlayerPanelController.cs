using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPanelController : MonoBehaviour {

    /// <summary>
    /// Number 0 - 3 to represent the player to display
    /// </summary>
    public int playerNumber = 0;

    public GameObject waitingTextObject;
    public GameObject joinedTextObject;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        var inputManager = InputManager.getCurrentInputManager();

        if (inputManager.playerControls.ContainsKey(playerNumber))
        {
            //Toggle visibility
            waitingTextObject.SetActive(false);
            joinedTextObject.SetActive(true);

            //Set message
            var inputName = inputManager.playerControls[playerNumber].getName();
            joinedTextObject.GetComponent<Text>().text = inputName + " joined";

        }
        else
        {
            //Toggle visibility
            waitingTextObject.SetActive(true);
            joinedTextObject.SetActive(false);
        }
    }
}
