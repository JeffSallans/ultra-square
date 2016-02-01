using UnityEngine;
using System.Collections;

/// <summary>
/// Manages the health displayed
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class HealthController : MonoBehaviour {

    /// <summary>
    /// Display the object sprite if the player's hits left is over the threashold
    /// </summary>
    public int hitThreshold;

    /// <summary>
    /// Player to check the threshold for
    /// </summary>
    public PlayerColor targetPlayer;

    private GameState gameState;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        gameState = GameState.getCurrentGameState();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

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
        spriteRenderer.enabled = overHealthThreshold;
    }
}
