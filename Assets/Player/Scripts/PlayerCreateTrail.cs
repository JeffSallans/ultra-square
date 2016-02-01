using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerCreateTrail : MonoBehaviour {

    /// <summary>
    /// Time it takes before the next trail can be placed
    /// </summary>
    public float cooldown;

    /// <summary>
    /// Trail object to create
    /// </summary>
    public GameObject trailPrefab;

    /// <summary>
    /// Time left until next use.  PRIVATE variable used for debugging.
    /// </summary>
    public float PRIVATE_timeUntilReady;

    private Player player;
    private PlayerInput input;

	// Use this for initialization
	void Start () {

        player = gameObject.GetComponent<Player>();

        input = InputManager.getCurrentInputManager()
            .playerControls[player.playerNumber];
	}
	
	// Update is called once per frame
	void Update () {
	    
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
                createTrail();
            }
        }

	}

    void createTrail()
    {
        var position = transform.position;

        var newTrail = (GameObject)Instantiate(trailPrefab, position, new Quaternion());
        //Set trail variables
        var trail = newTrail.GetComponent<Trail>();
        trail.playerCreated = player;
        trail.playerColor = player.playerColor;
    }
}
