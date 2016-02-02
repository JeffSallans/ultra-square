using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Displays the time left in the match
/// </summary>
[RequireComponent(typeof(Text))]
public class TimeLeftController : MonoBehaviour {

    private GameState gameState;

    private Text text;

	// Use this for initialization
	void Start () {
        gameState = GameState.getCurrentGameState();
        text = gameObject.GetComponent<Text>();

        //Default hidden
        var color = text.color;
        color.a = 0;
        text.color = color;
	}
	
	// Update is called once per frame
	void Update () {

        //Fix time to 2 decimal places
        text.text = gameState.timeLeft.ToString("F0");
	}
}
