using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2ButtonScript : MonoBehaviour
{
        private void OnMouseDown()
    {
        Debug.Log("button2 presed");
        SceneManager.LoadScene("Level 2");
    }

}
