using UnityEngine;
using System.Collections;

/// <summary>
/// Adds ability to the player to activate attack
/// </summary>
[RequireComponent(typeof(Player))]
public class Smack : MonoBehaviour {

    /// <summary>
    /// Time it takes before the action is available, in seconds
    /// </summary>
    public float cooldown;

    /// <summary>
    /// Hitbox for smack attack
    /// </summary>
    public GameObject smackHitBox;

    /// <summary>
    /// How long the hitbox should be enabled, in seconds
    /// </summary>
    public float showHitBoxDuration;

    /// <summary>
    /// If action is ready to use
    /// </summary>
    public bool actionIsReady;

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
        //Check if action is used
        if (actionIsReady)
        {
            if (input.getActionPressDown())
            {
                smackHitBox.SetActive(true);
                StartCoroutine(hideSmackHitbox());
                StartCoroutine(startCooldown());
            }
        }
    }

    /// <summary>
    /// Function for coroutines.
    /// Call to start the cooldown on an ability
    /// MODIFIES: actionIsReady
    /// </summary>
    /// <returns>Type used by Coroutines</returns>
    IEnumerator startCooldown()
    {
        actionIsReady = false;
        yield return new WaitForSeconds(cooldown);
        actionIsReady = true;
    }

    /// <summary>
    /// Function for coroutines.
    /// Wait showHitBoxDuration number of seconds and then hide smack hitbox.
    /// MODIFIES: smackHitBox.active
    /// </summary>
    /// <returns>Type used by Coroutines</returns>
    IEnumerator hideSmackHitbox()
    {
        yield return new WaitForSeconds(showHitBoxDuration);
        smackHitBox.SetActive(false);
    }
}

