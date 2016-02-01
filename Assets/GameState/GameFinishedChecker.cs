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
	    
        if (gameState.pinkPlayer.hitsLeft < 0)
        {
            gameState.winningPlayer = PlayerColor.Green;
            StartCoroutine(endMatch());
        }
        
        if (gameState.greenPlayer.hitsLeft < 0)
        {
            gameState.winningPlayer = PlayerColor.Green;
            StartCoroutine(endMatch());
        }
    }

    IEnumerator endMatch()
    {
        gameOverText.SetActive(true);
        Time.timeScale = gameOverTimeScale;

        //Hold execution for X seconds
        yield return new WaitForSeconds(showGameOverDuration);

        Application.LoadLevel(afterMatchScene);
    }
}
