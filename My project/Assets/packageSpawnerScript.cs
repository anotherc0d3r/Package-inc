using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class packageSpawnerScript : MonoBehaviour
{
    List<GameObject> packageList = new List<GameObject>();
    public GameObject packageBrown;
    public GameObject packageOrange;
    public GameObject packageBlue;
    // Can change spawnRate from editor
    private float timer = 0;
    // To control spawn rates
    public float initialSpawnRate = 10;
    private float currentSpawnRate;
    public float difficulty = 1f;

    // Start is called before the first frame update
    void Start()
    {
    // Adds all packages to array to randomly choose from
        packageList.Add(packageBrown);
        packageList.Add(packageBlue);
        packageList.Add(packageOrange);
    }

    // Update is called once per frame
    void Update()
    {
        // Increases spawn rate over time
        currentSpawnRate = initialSpawnRate - (difficulty*Time.time);
        // Slows the time between spawns to spawnRate value in seconds
        if (timer < currentSpawnRate)
        {
            timer = timer + Time.deltaTime;
        }else
        {
        //Chooses a random package from the prefab list
        int packageIndex = UnityEngine.Random.Range(0,3);
        Instantiate(packageList[packageIndex], transform.position, transform.rotation);
            timer = 0;
        }
        }
   
}
