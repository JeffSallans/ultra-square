using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Manages the health displayed
/// </summary>
[RequireComponent(typeof(Image))]
public class HealthController : MonoBehaviour {

    /// <summary>
    /// Display the object sprite if the player's hits left is over the threashold
    /// </summary>
    public int hitThreshold;

    /// <summary>
    /// Player to check the threshold for
    /// </summary>
    public PlayerColor targetPlayer;

    private Image image;

	// Use this for initialization
	void Start () {
        image = gameObject.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

        var gameState = GameState.getCurrentGameState();

        Player player;
        if (targetPlayer == PlayerColor.Green)
        {
            player = gameState.greenPlayer;
        }
        else
        {
            player = gameState.pinkPlayer;
        }

        var overHealthThreshold = player.hitsLeft > hitThreshold;
        image.enabled = overHealthThreshold;
    }
}
