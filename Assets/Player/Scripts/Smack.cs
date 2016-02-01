using UnityEngine;
using System.Collections;

/// <summary>
/// Adds ability to the player to activate attack
/// </summary>
[RequireComponent(typeof(Player))]
public class Smack : MonoBehaviour {

    /// <summary>
    /// Time it takes before the next trail can be placed
    /// </summary>
    public float cooldown;

    /// <summary>
    /// Hitbox for smack attack
    /// </summary>
    public GameObject smackHitBox;

    /// <summary>
    /// Time left until next use.  PRIVATE variable used for debugging.
    /// </summary>
    public float PRIVATE_timeUntilReady;

    private Player player;
    private PlayerInput input;

    // Use this for initialization
    void Start()
    {

        player = gameObject.GetComponent<Player>();

        input = InputManager.getCurrentInputManager()
            .playerControls[player.playerNumber];
    }

    // Update is called once per frame
    void Update()
    {

        //Unable to take action
        if (PRIVATE_timeUntilReady > 0)
        {
            PRIVATE_timeUntilReady -= Time.deltaTime;
        }
        //Check if action is used
        else
        {
            if (input.getActionPressDown())
            {
                smackHitBox.SetActive(true);
            }
            else
            {
                //Last frame was using the ability
                if (smackHitBox.activeSelf)
                {
                    PRIVATE_timeUntilReady = cooldown;
                }

                smackHitBox.SetActive(false);
            }
        }

    }
}

