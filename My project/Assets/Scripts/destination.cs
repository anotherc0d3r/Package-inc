using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destination : MonoBehaviour
{
    public logicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = FindObjectOfType<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     Debug.Log("hit");
     logicScript.addScore();
    }
}