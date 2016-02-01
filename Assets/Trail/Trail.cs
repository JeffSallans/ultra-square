using UnityEngine;
using System.Collections;

/// <summary>
/// Holds all public data for a player used in the match
/// </summary>
[RequireComponent(typeof(Animator))]
public class Trail : MonoBehaviour {

    /// <summary>
    /// A reference to the player creating this
    /// </summary>
    public Player playerCreated;

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
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        //Set initial color
        playerColor = PRIVATE_playerColor;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
