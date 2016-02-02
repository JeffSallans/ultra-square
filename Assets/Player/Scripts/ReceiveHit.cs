using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Collider2D))]
public class ReceiveHit : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D attackBox)
    {
        //Cannot hit self
        if (attackBox.gameObject == player.GetComponent<Smack>().smackHitBox) return;

        //Cannot hit invulnerable
        if (player.isInvulnerable) return;

        player.hitsLeft--;
        player.isInvulnerable = true;

        var animator = gameObject.GetComponent<Animator>();

        animator.SetTrigger("playerHit");

    }
}
