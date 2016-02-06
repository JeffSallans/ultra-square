using UnityEngine;
using System.Collections;

public class PersistUntilReplaced : MonoBehaviour {

    /// <summary>
    /// Name of the object this is on
    /// </summary>
    public string OBJECT_NAME = "";

    // Use this for initialization
    void Awake()
    {
        //OBJECT_NAME must be defined
        if (OBJECT_NAME == "")
        {
            throw new UnityException("PersistUntilReplace requires object name not be null");
        }

        //Current game object name must not match
        if (gameObject.name == OBJECT_NAME)
        {
            throw new UnityException("PersistUntilReplace requires the game object be named different than OBJECT_NAME");
        }

        //Keep state over multiple screens
        DontDestroyOnLoad(gameObject);

        //If another Input Manager is detected, remove it
        var oldObject = GameObject.Find(OBJECT_NAME);

        if (oldObject != null)
        {
            Destroy(oldObject);
        }

        //Assign name
        gameObject.name = OBJECT_NAME;
    }

    /// <summary>
    /// Returns the current object
    /// </summary>
    /// <returns></returns>
    public static GameObject getCurrent(string objectName)
    {
        //Current object, before the replace happends
        var gameObjectBeforeInitFinishes = GameObject.Find("NEW_" + objectName);
        if (gameObjectBeforeInitFinishes != null)
        {
            return gameObjectBeforeInitFinishes;
        }

        //Current object, after the replace happends
        return GameObject.Find(objectName);
    }
}
