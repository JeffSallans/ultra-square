using UnityEngine;
using System.Collections;

/// <summary>
/// Holds all public data for a trail used in the match
/// </summary>
public class GameState : MonoBehaviour {

    public Player pinkPlayer;
    public Player greenPlayer;

    /// <summary>
    /// Max time duration of the match, in seconds
    /// </summary>
    public float gameDuration;

    /// <summary>
    /// Time left in the match in seconds
    /// </summary>
    public float timeLeft;

    public PlayerColor? winningPlayer;

    /// <summary>
    /// Name of the object this is on
    /// </summary>
    public static string OBJECT_NAME = "GameState";

    // Use this for initialization
    void Start () {

        //Keep state over multiple screens
        DontDestroyOnLoad(gameObject);

        //If another Input Manager is detected, remove it
        gameObject.name = "NEW_" + OBJECT_NAME;
        var oldObject = GameObject.Find(OBJECT_NAME);

        if (oldObject != null)
        {
            Destroy(oldObject);
        }

        //Assign name
        gameObject.name = OBJECT_NAME;
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
	}

    /// <summary>
    /// Returns the current game state if it exists
    /// </summary>
    /// <returns></returns>
    public static GameState getCurrentGameState()
    {
        return GameObject.Find(GameState.OBJECT_NAME).GetComponent<GameState>();
    }
}
