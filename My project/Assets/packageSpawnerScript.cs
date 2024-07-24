using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class packageSpawnerScript : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject packageBrown;
    public GameObject packageOrange;
    public GameObject packageBlue;
    // Can change spawnRate from editor
    public float spawnRate = 10;
    private float timer = 0;

    

    // Start is called before the first frame update
    void Start()
    {
    // Adds all packages to array to randomly choose from
        prefabList.Add(packageBrown);
        prefabList.Add(packageBlue);
        prefabList.Add(packageOrange);

           int prefabIndex = UnityEngine.Random.Range(0,3);
        Instantiate(prefabList[prefabIndex]);

    //spawns one package instantly 
    // Instantiate(package, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Slows the spawn to spawnRate value in seconds
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }else
        {
            Instantiate(package, transform.position, transform.rotation);
            timer = 0;
        }
        }
   
}
