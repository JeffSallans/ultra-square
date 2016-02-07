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

            StartCoroutine(activateSlowDown(targetPlayer, slowDownPickup));
        }
        else {

            player.hitsLeft--;
            player.isInvulnerable = true;

            var animator = gameObject.GetComponent<Animator>();

            animator.SetTrigger("playerHit");
        }
    }

    /// <summary>
    /// Coroutine function that calls logic when a player picks up slowdown.
    /// </summary>
    /// <param name="target">Player that did not pickup slowdown</param>
    /// <param name="slowDown">Slow down data class</param>
    /// <returns>Enumerator to be used by coroutines</returns>
    IEnumerator activateSlowDown(Player target, SlowDown slowDown)
    {
        //Show picked up
        slowDown.gameObject.GetComponent<Animator>().SetTrigger("pickupHit");
        slowDown.gameObject.GetComponent<Animator>().SetTrigger("hide");

        //Don't trigger collider again
        slowDown.gameObject.GetComponent<Collider2D>().enabled = false;

        //Check if there is a slowdown icon on the player
        var slowDownIconOnPlayerAnimator = target.gameObject.transform.Find("SlowDownIcon").gameObject.GetComponent<Animator>();
        slowDownIconOnPlayerAnimator.SetTrigger("fadein");

        //Slow down picked up logic
        target.speed -= slowDown.flatSpeedReduction;
        yield return new WaitForSeconds(slowDown.speedRecutionDuration - slowDown.speedRecutionWarningDuration);

        //Show user slowdown is almost up
        slowDownIconOnPlayerAnimator.SetTrigger("activeFinishing");
        yield return new WaitForSeconds(slowDown.speedRecutionWarningDuration);

        target.speed += slowDown.flatSpeedReduction;
    }
}
