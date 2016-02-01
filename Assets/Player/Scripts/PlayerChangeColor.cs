using UnityEngine;
using System.Collections;

/// <summary>
/// Listen for color change presses
/// </summary>
[RequireComponent(typeof(Player))]
public class PlayerChangeColor : MonoBehaviour {

    private Player player;

    // Use this for initialization
	void Start () {
        player = gameObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        var input = InputManager.getCurrentInputManager()
                    .playerControls[player.playerNumber];

        if (input.getActionPressDown())
        {
            if (player.playerColor == PlayerColor.Pink)
            {
                player.playerColor = PlayerColor.Green;
            }
            else
            {
                player.playerColor = player.playerColor + 1;
            }
        }
	}
}
