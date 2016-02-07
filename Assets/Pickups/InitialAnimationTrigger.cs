using UnityEngine;
using System.Collections;

/// <summary>
/// Set an animation trigger on start
/// </summary>
[RequireComponent(typeof(Animator))]
public class InitialAnimationTrigger : MonoBehaviour {

    /// <summary>
    /// Name of animation trigger to set
    /// </summary>
    public string animatorTrigger;

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<Animator>().SetTrigger(animatorTrigger);
	}
}
