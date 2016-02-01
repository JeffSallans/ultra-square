using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Logic for the start of the game
/// </summary>
[RequireComponent(typeof(Text))]
public class GameStartController : MonoBehaviour {

    public GameObject gameStartText;

    /// <summary>
    /// The initial text to display
    /// </summary>
    public int startingCount = 3;

    /// <summary>
    /// The duration of each count in seconds
    /// </summary>
    public float countDownIntervalDuration;

	// Use this for initialization
	void Start () {
        StartCoroutine(startMatch());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator startMatch()
    {
        gameObject.GetComponent<Text>().text = startingCount.ToString();
        //Hold execution for X seconds
        yield return new WaitForSeconds(countDownIntervalDuration);
        startingCount--;
        gameObject.GetComponent<Text>().text = startingCount.ToString();

        //Hold execution for X seconds
        yield return new WaitForSeconds(countDownIntervalDuration);
        startingCount--;
        gameObject.GetComponent<Text>().text = startingCount.ToString();

        //Hold execution for X seconds
        yield return new WaitForSeconds(countDownIntervalDuration);
        startingCount--;
        gameObject.GetComponent<Text>().text = startingCount.ToString();

        //Hold execution for X seconds
        yield return new WaitForSeconds(countDownIntervalDuration);
        gameObject.GetComponent<Text>().text = "FIGHT";
        gameObject.GetComponent<Animator>().SetTrigger("fadeout");
    }
}
