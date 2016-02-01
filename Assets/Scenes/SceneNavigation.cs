using UnityEngine;
using System.Collections;

public class SceneNavigation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadStart()
    {
        Application.LoadLevel("start");
    }

    public void loadInput()
    {
        Application.LoadLevel("setControls");
    }

    public void loadMatch()
    {
        Application.LoadLevel("match");
    }
}
