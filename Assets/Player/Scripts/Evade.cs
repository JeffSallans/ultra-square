using UnityEngine;
using System.Collections;

/// <summary>
/// Adds ability for the player to quickly move back from the direction they were going
/// </summary>
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMovement))]
public class Evade : MonoBehaviour {

    /// <summary>
    /// Time in seconds before the next evade can occur
    /// </summary>
    public float cooldown;

    /// <summary>
    /// Distance to jump backwards
    /// </summary>
    public float evadeDistance;

    /// <summary>
    /// Time it takes to jump backwards
    /// </summary>
    public float evadeDuration;

    public float evadeSpeed
    {
        get
        {
            return evadeDistance / evadeDuration;
        }
    }

    private bool _isEvading;
    public bool isEvading
    {
        get
        {
            return isEvading;
        }
        set
        {
            playerMovement.enabled = !value;
            isEvading = value;
        }
    }

    private Vector3 evadeFinalPosition;

    /// <summary>
    /// Time left until next use.  PRIVATE variable used for debugging.
    /// </summary>
    public float PRIVATE_timeUntilReady;

    private Player player;
    private PlayerInput input;
    private PlayerMovement playerMovement;

    // Use this for initialization
    void Start()
    {

        player = gameObject.GetComponent<Player>();

        input = InputManager.getCurrentInputManager()
            .playerControls[player.playerNumber];

        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEvading)
        {

        }

        //Unable to take action
        if (PRIVATE_timeUntilReady > 0)
        {
            //Check if effect finished
            if (!playerMovement.enabled && PRIVATE_timeUntilReady < cooldown - evadeDuration)
            {
                playerMovement.enabled = true;
                //player.speed *= -1;
            }

            PRIVATE_timeUntilReady -= Time.deltaTime;
        }
        //Check if action is used
        else
        {
            if (input.getSecondaryActionPressDown())
            {
                var pos = transform.position;
                var inputDirection = new Vector3(input.getHorizontalAxis(), input.getVerticalAxis(), 0);

                //Move a certain distance away
                transform.position = pos - (evadeDistance * inputDirection.normalized);

                playerMovement.enabled = false;

                PRIVATE_timeUntilReady = cooldown;
            }
        }
    }
}
