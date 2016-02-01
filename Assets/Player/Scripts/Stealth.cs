using UnityEngine;
using System.Collections;

/// <summary>
/// Adds ability for the player to become invisible while holding
/// </summary>
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(SpriteRenderer))]
public class Stealth : MonoBehaviour {
    /// <summary>
    /// Time it takes before the next trail can be placed
    /// </summary>
    public float cooldown;

    /// <summary>
    /// Time left until next use.  PRIVATE variable used for debugging.
    /// </summary>
    public float PRIVATE_timeUntilReady;

    private Player player;
    private PlayerInput input;
    private SpriteRenderer playerRender;

    // Use this for initialization
    void Start()
    {

        player = gameObject.GetComponent<Player>();

        input = InputManager.getCurrentInputManager()
            .playerControls[player.playerNumber];

        playerRender = gameObject.GetComponent<SpriteRenderer>();
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
            if (input.getSecondaryActionHold())
            {
                playerRender.enabled = false;
            }
            else
            {
                //Last frame was using the ability
                if (playerRender.enabled == false)
                {
                    PRIVATE_timeUntilReady = cooldown;
                }

                playerRender.enabled = true;
            }
        }

    }
}
