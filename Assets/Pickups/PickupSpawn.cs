using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Handles when the pickup is active, where it is placed, and when it is inactive
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PickupSpawn : MonoBehaviour {

    /// <summary>
    /// Number of seconds to wait until pickup spawns
    /// </summary>
    public float spawnAfterDuration;

    /// <summary>
    /// Number of seconds the pickup is visible
    /// </summary>
    public float activeDuration;

    /// <summary>
    /// Number of seconds the pickup indicates it is leaving soon
    /// </summary>
    public float activeDurationWarning;

    /// <summary>
    /// Possible spawn locations
    /// </summary>
    public List<GameObject> spawnLocations;

    private Animator animator;
    private Collider2D collider;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        collider = gameObject.GetComponent<Collider2D>();

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        //Inactive
        collider.enabled = false;
        animator.SetTrigger("hide");

        //Set spawn location
        var randomLocationIndex = (int)Mathf.Floor(Random.Range(0, spawnLocations.Count - 0.01f));
        var selectedSpawnLocation = spawnLocations[randomLocationIndex];
        transform.position = selectedSpawnLocation.transform.position;

        yield return new WaitForSeconds(spawnAfterDuration);
        
        //Show pickup is available
        collider.enabled = true;
        animator.SetTrigger("fadein");

        yield return new WaitForSeconds(activeDuration - activeDurationWarning);

        //Show pickup is almost gone
        animator.SetTrigger("activeFinishing");

        yield return new WaitForSeconds(activeDurationWarning);

        //Finished with pickup
        Destroy(gameObject);
    }
}
