using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLeftController : MonoBehaviour {

    public Text timeLeftText;

    private GameState gameState;

	// Use this for initialization
	void Start () {
        gameState = GameState.getCurrentGameState();
	}
	
	// Update is called once per frame
	void Update () {

        //Fix time to 2 decimal places
        timeLeftText.text = gameState.timeLeft.ToString("F");
	}
}
