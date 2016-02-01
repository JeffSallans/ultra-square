using UnityEngine;
using System.Collections;

public enum PlayerColor
{
    Green,
    //Yellow,
    Pink
}

/// <summary>
/// Holds all public data for a trail used in the match
/// </summary>
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour {

    /// <summary>
    /// The ID associated with the player
    /// </summary>
    public int playerNumber;

    /// <summary>
    /// Number of hits allowed per player
    /// </summary>
    public int startingHits;

    /// <summary>
    /// The number of hits a player can take
    /// </summary>
    public int hitsLeft;

    /// <summary>
    /// How fast the player should move
    /// </summary>
    public float speed;

    /// <summary>
    /// Do not modify this variable only for debugging purposes
    /// </summary>
    public PlayerColor PRIVATE_playerColor;

    public PlayerColor playerColor
    {
        get
        {
            return PRIVATE_playerColor;
        }
        set
        {
            //Change animiation to show state
            if (value == PlayerColor.Green)
            {
                animator.SetTrigger("toGreen");
            }
            //if (value == PlayerColor.Yellow)
            //{
            //    animator.SetTrigger("toYellow");
            //}
            if (value == PlayerColor.Pink)
            {
                animator.SetTrigger("toPink");
            }

            PRIVATE_playerColor = value;
        }
    }

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();

        //Set appropriate start color
        playerColor = PRIVATE_playerColor;

        //Set hits left
        hitsLeft = startingHits;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
