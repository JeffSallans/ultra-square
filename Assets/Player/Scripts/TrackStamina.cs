using UnityEngine;
using System.Collections;

/// <summary>
/// Reduce the player stamina based on distance traveled
/// </summary>
[RequireComponent(typeof(Player))]
public class TrackStamina : MonoBehaviour {

    /// <summary>
    /// Rate to recover stamina per second when resting
    /// </summary>
    public float staminaRecoveryRate;

    private Player player;

    private PlayerInput playerInput;

	// Use this for initialization
	void Start () {

        player = gameObject.GetComponent<Player>();
        playerInput = InputManager.getCurrentInputManager()
            .playerControls[player.playerNumber];
	}
	
	// Update is called once per frame
	void Update () {

        var playerMoving = (Mathf.Abs(playerInput.getHorizontalAxis()) > 0 || Mathf.Abs(playerInput.getVerticalAxis()) > 0);

        //If moving spend stamina
        if (playerMoving && player.distanceCanTravel > 0) {

            var distanceTraveledThisFrame = player.speed * Time.deltaTime;
            player.distanceCanTravel -= distanceTraveledThisFrame;
        }
        //If not moving then recover stamina
        else if (!playerMoving && player.distanceCanTravel < player.maxDistanceCanTravel)
        {
            player.distanceCanTravel += staminaRecoveryRate * Time.deltaTime;
        }

        //Clamp value
        player.distanceCanTravel = Mathf.Clamp(player.distanceCanTravel, 0, player.maxDistanceCanTravel);

    }
}
