using UnityEngine;
using System.Collections;

/// <summary>
/// The movement for the player
/// </summary>
[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour {

    private Player player;

    /// <summary>
    /// Collider that defines the space the player can move
    /// </summary>
    public BoxCollider2D movableArea;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        var input = InputManager.getCurrentInputManager()
            .playerControls[player.playerNumber];
        
        var pos = transform.position;

        pos.x += player.speed * input.getHorizontalAxis();
        pos.y += player.speed * input.getVerticalAxis();

        var maxX = movableArea.size.x / 2f;
        var minX = -movableArea.size.x / 2f;
        var maxY = movableArea.size.y / 2f;
        var minY = -movableArea.size.y / 2f;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
	}
}
