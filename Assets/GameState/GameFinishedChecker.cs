using UnityEngine;
using System.Collections;

/// <summary>
/// Check if the game is finished
/// </summary>
[RequireComponent(typeof(GameState))]
public class GameFinishedChecker : MonoBehaviour {

    /// <summary>
    /// Game object to show the game is over
    /// </summary>
    public GameObject gameOverText;

    /// <summary>
    /// How long to show the end game sequence, in seconds
    /// </summary>
    public float showGameOverDuration;

    /// <summary>
    /// The modified timescale of the game during th end game sequence
    /// </summary>
    public float gameOverTimeScale;

    /// <summary>
    /// Screen to load after the match
    /// </summary>
    public string afterMatchScene;

    private GameState gameState;

	// Use this for initialization
	void Start () {
        gameState = gameObject.GetComponent<GameState>();
	}
	
	// Update is called once per frame
	void Update () {

        //Do not update game state if determined
        if (gameState.winningPlayer != null) return;

        if (gameState.pinkPlayer.hitsLeft <= 0)
        {
            gameState.winningPlayer = PlayerColor.Green;
            StartCoroutine(endMatch());
        }
        
        if (gameState.greenPlayer.hitsLeft <= 0)
        {
            gameState.winningPlayer = PlayerColor.Pink;
            StartCoroutine(endMatch());
        }

        if (gameState.timeLeft <= 0)
        {
            //If green has more
            if (gameState.greenPlayer.hitsLeft > gameState.pinkPlayer.hitsLeft)
            {
                gameState.winningPlayer = PlayerColor.Green;
            }
            //If pink has more
            else if (gameState.greenPlayer.hitsLeft < gameState.pinkPlayer.hitsLeft)
            {
                gameState.winningPlayer = PlayerColor.Pink;
            }
            //Otherwise it is a draw

            StartCoroutine(endMatch());
        }
    }

    IEnumerator endMatch()
    {
        //Disable abilities
        gameState.pinkPlayer.gameObject.GetComponent<Smack>().enabled = false;
        gameState.greenPlayer.gameObject.GetComponent<Smack>().enabled = false;

        gameOverText.SetActive(true);

        var originalTimeScale = Time.timeScale;
        Time.timeScale = gameOverTimeScale;

        //Hold execution for X seconds
        yield return new WaitForSeconds(showGameOverDuration);

        //Remove reference to avoid breaking things
        gameState.greenPlayer = null;
        gameState.pinkPlayer = null;

        //Reset time scale
        Time.timeScale = originalTimeScale;

        Application.LoadLevel(afterMatchScene);
    }
}
