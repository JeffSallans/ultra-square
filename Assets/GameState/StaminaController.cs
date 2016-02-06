using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Manages the stamina bar display
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class StaminaController : MonoBehaviour {

    /// <summary>
    /// Width of the stamina bar when stamina is maxed out
    /// </summary>
    public float maxStaminaWidth;

    /// <summary>
    /// Width of the stamina bar when stamina is 0
    /// </summary>
    public float minStaminaWidth;

    /// <summary>
    /// Player that you are representing stamina for
    /// </summary>
    public Player player;

    private RectTransform rectTransform;

    // Use this for initialization
    void Start () {

        rectTransform = gameObject.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {

        var getLeftAndRight = rectTransform.offsetMin;

        //Corrispond stamina width to value
        var left = (maxStaminaWidth - minStaminaWidth) * ((player.maxDistanceCanTravel - player.distanceCanTravel) / player.maxDistanceCanTravel) + minStaminaWidth;
        getLeftAndRight.x = left;

        rectTransform.offsetMin = getLeftAndRight;
    }
}
