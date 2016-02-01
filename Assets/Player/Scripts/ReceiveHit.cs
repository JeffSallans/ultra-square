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
        if (attackBox.gameObject == player.GetComponent<Smack>().smackHitBox) return;

        player.hitsLeft--;

        var animator = gameObject.GetComponent<Animator>();

        animator.SetTrigger("playerHit");
    }
}
