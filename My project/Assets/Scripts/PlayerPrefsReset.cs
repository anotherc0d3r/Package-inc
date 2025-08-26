using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsReset : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();
        // Completely resets all playerprefs (saved data) at the start of the game
    }

}
