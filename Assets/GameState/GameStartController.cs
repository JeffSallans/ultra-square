using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Logic for the start of the game
/// </summary>
[RequireComponent(typeof(Text))]
public class GameStartController : MonoBehaviour {

    /// <summary>
    /// Object to enable after the countdown finishes
    /// </summary>
    public GameObject gameTimerTextObject;

    /// <summary>
    /// The initial text to display
    /// </summary>
    public int startingCount = 3;

    /// <summary>
    /// The duration of each count in seconds
    /// </summary>
    public float countDownIntervalDuration;

    private GameState gameState;

	// Use this for initialization
	void Start () {

        StartCoroutine(startMatch());
	}
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator startMatch()
    {
        gameTimerTextObject.GetComponent<Animator>().SetTrigger("hide");

        yield return new WaitForSeconds(.05f);

        gameState = GameState.getCurrentGameState();

        //Disable movement
        gameState.pinkPlayer.gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameState.greenPlayer.gameObject.GetComponent<PlayerMovement>().enabled = false;

        gameObject.GetComponent<Text>().text = startingCount.ToString();
        gameObject.GetComponent<Animator>().SetTrigger("fadeout");

        //Hold execution for X seconds
        yield return new WaitForSeconds(countDownIntervalDuration);
        startingCount--;
        gameObject.GetComponent<Text>().text = startingCount.ToString();
        gameObject.GetComponent<Animator>().SetTrigger("fadeout");

        //Hold execution for X seconds
        yield return new WaitForSeconds(countDownIntervalDuration);
        startingCount--;
        gameObject.GetComponent<Text>().text = startingCount.ToString();
        gameObject.GetComponent<Animator>().SetTrigger("fadeout");

        //Hold execution for X seconds
        yield return new WaitForSeconds(countDownIntervalDuration);
        gameObject.GetComponent<Text>().text = "FIGHT";
        gameObject.GetComponent<Animator>().SetTrigger("fadeout");

        //Enable movement
        gameState.pinkPlayer.gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameState.greenPlayer.gameObject.GetComponent<PlayerMovement>().enabled = true;

        yield return new WaitForSeconds(countDownIntervalDuration);
        gameTimerTextObject.GetComponent<Animator>().SetTrigger("fadein");
    }
}
