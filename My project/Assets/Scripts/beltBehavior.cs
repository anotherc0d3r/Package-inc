using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }


    // Watch for an object on top of the belt, if there is, move it.

    protected abstract void WatchForItem();
}
