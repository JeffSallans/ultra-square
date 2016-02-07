using UnityEngine;
using System.Collections;

/// <summary>
/// Data on pickup for slowing down the enemy
/// </summary>
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SlowDown : MonoBehaviour {

    /// <summary>
    /// The amount to reduce the opponents speed by when the pickup is picked up
    /// </summary>
    public float flatSpeedReduction;

    /// <summary>
    /// How long the slowdown effect takes place
    /// </summary>
    public float speedRecutionDuration;

    /// <summary>
    /// How long the slowdown indicates it will be removed soon
    /// </summary>
    public float speedRecutionWarningDuration;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
