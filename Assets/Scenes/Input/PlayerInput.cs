using UnityEngine;
using System.Collections;

public interface PlayerInput {

    /// <summary>
    /// Returns a unique identification of the player input
    /// </summary>
    /// <returns>A string that is unique</returns>
    string getName();

    /// <summary>
    /// Returns the number for the horizontal movement axis.  
    /// Negative value is left, positive value is right.
    /// </summary>
    /// <returns>A number between -1.0f and 1.0f. Resting axis is 0f</returns>
    float getHorizontalAxis();

    /// <summary>
    /// Returns the number for the vertical movement axis
    /// Negative value is down, positive value is up.
    /// </summary>
    /// <returns>A number between -1.0f and 1.0f. Resting axis is 0f</returns>
    float getVerticalAxis();

    /// <summary>
    /// Determines if the action button was pressed down.
    /// </summary>
    /// <returns>True if the button is pressed for this update(), false if the button is held down or released</returns>
    bool getActionPressDown();

    /// <summary>
    /// Determines if the action button is being held down.
    /// </summary>
    /// <returns>True if the button is held, false if the button is released</returns>
    bool getActionHold();

    /// <summary>
    /// Determines if the secondary action button was pressed down.
    /// </summary>
    /// <returns>True if the button is pressed for this update(), false if the button is held down or released</returns>
    bool getSecondaryActionPressDown();

    /// <summary>
    /// Determines if the secondary action button is being held down.
    /// </summary>
    /// <returns>True if the button is held, false if the button is released</returns>
    bool getSecondaryActionHold();
}
