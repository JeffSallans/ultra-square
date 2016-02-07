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
    public float stage1Speed;

    /// <summary>
    /// How fast the player should move with 2 or less health
    /// </summary>
    public float stage2Speed;

    /// <summary>
    /// The speed modifications to the player
    /// </summary>
    private float speedModified = 0;

    /// <summary>
    /// Getter for speed of the player depending on the conditions
    /// </summary>
    public float speed
    {
        get
        {
            if (hitsLeft <= 2)
            {
                return stage2Speed + speedModified;
            }
            else
            {
                return stage1Speed + speedModified;
            }
        }
        set
        {
            speedModified = value - speed;
        }
    }

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
            if (value == PlayerColor.Pink)
            {
                animator.SetTrigger("toPink");
            }

            PRIVATE_playerColor = value;
        }
    }

    /// <summary>
    /// True when player cannot be hit
    /// </summary>
    public bool PRIVATE_isInvulnerable;

    /// <summary>
    /// How long player in invulnerable in seconds
    /// </summary>
    public float invulnerableDuration;

    /// <summary>
    /// Wrapper for managing animations
    /// </summary>
    public bool isInvulnerable
    {
        get
        {
            return PRIVATE_isInvulnerable;
        }
        set
        {
            PRIVATE_isInvulnerable = value;
            animator.SetBool("isInvulnerable", value);

            if (PRIVATE_isInvulnerable)
            {
                StopCoroutine(turnOffInvul());
                StartCoroutine(turnOffInvul());
            }
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

    /// <summary>
    /// Coroutine function
    /// Turns off invulnerability
    /// MODIFIES: PRIVATE_isInvulnerable
    /// </summary>
    /// <returns>Something used by Coroutines</returns>
    IEnumerator turnOffInvul()
    {
        yield return new WaitForSeconds(invulnerableDuration);
        isInvulnerable = false;
    }
}
