using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Unlocked level", 2); // Unlocks level 2
        Debug.Log("Level 2 unlocked");
    }
}
