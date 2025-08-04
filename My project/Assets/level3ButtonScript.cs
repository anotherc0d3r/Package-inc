using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3ButtonScript : MonoBehaviour
{
        private void OnMouseDown()
    {
        Debug.Log("button3 presed");
        SceneManager.LoadScene("Level 3");
    }

}
