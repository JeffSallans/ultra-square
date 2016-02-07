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

        var slowDownPickup = attackBox.gameObject.GetComponent<SlowDown>();
        if (slowDownPickup != null)
        {
            var gameState = GameState.getCurrentGameState();

            var targetPlayer = gameState.getOpponent(player);

            StartCoroutine(activateSlowDown(targetPlayer, 
                slowDownPickup.flatSpeedReduction, slowDownPickup.speedRecutionDuration));

            //Destroy the used slow down pickup
            Destroy(attackBox.gameObject);
        }
        else {

            player.hitsLeft--;
            player.isInvulnerable = true;

            var animator = gameObject.GetComponent<Animator>();

            animator.SetTrigger("playerHit");
        }
    }

    IEnumerator activateSlowDown(Player target, float speedReduceBy, float reductionDuration)
    {
        target.speed -= speedReduceBy;
        yield return new WaitForSeconds(reductionDuration);
        target.speed += speedReduceBy;
    }
}
