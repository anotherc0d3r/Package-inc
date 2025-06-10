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
    public float initialSpawnRate;
    public float currentSpawnRate;
    public float difficulty; //Changes how fast the spawnrate changes
    private float levelTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // Adds all packages to array to randomly choose from
        packageList.Add(packageBrown);
        packageList.Add(packageBlue);
        packageList.Add(packageOrange);
        // Resets current spawn rate
        currentSpawnRate = initialSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        // Increases spawn rate over time
        levelTimer += Time.deltaTime;
        currentSpawnRate = initialSpawnRate - (difficulty * levelTimer);
        // Slows the time between spawns to spawnRate value in seconds
        if (timer < currentSpawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            //Chooses a random package from the prefab list
            int packageIndex = UnityEngine.Random.Range(0, 3);
            Instantiate(packageList[packageIndex], transform.position, transform.rotation);
            timer = 0;

        }
    }
    public void resetSpawnRate()
    {
        levelTimer = 0f;
        currentSpawnRate = initialSpawnRate;
        
    }
   
}
