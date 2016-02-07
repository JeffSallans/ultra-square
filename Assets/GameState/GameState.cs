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
    void Awake()
    {

        //Keep state over multiple screens
        DontDestroyOnLoad(gameObject);

        //If another Input Manager is detected, remove it
        var oldObject = GameObject.Find(OBJECT_NAME);

        if (oldObject != null)
        {
            Destroy(oldObject);
        }

        //Assign name
        gameObject.name = OBJECT_NAME;
    }

    void Start () {

            //Set time left on new game
            timeLeft = gameDuration;
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
	}

    /// <summary>
    /// Returns the opponent of the given player
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public Player getOpponent(Player player)
    {
        if (player == greenPlayer)
        {
            return pinkPlayer;
        }
        else if (player == pinkPlayer)
        {
            return greenPlayer;
        }

        return null;
    }

    /// <summary>
    /// Returns the current game state if it exists
    /// </summary>
    /// <returns></returns>
    public static GameState getCurrentGameState()
    {
        var gameObjectBeforeInitFinishes = GameObject.Find("NEW_" + GameState.OBJECT_NAME);

        if (gameObjectBeforeInitFinishes != null)
        {
            return gameObjectBeforeInitFinishes.GetComponent<GameState>();
        }

        return GameObject.Find(GameState.OBJECT_NAME).GetComponent<GameState>();
    }
}
