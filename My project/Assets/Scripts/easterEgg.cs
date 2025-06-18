using UnityEngine;
using System.Collections.Generic;


public class EasterEgg : MonoBehaviour
{

    List<GameObject> packageList = new List<GameObject>();
    public GameObject newPackage1;        // Assign your package prefab in Inspector
    public GameObject newPackage2;
    public GameObject newPackage3;
    public RectTransform spawnArea;       // Assign your UI Canvas RectTransform

    public float spawnHeight = 6f;        // Y-position above the top of the screen

    public Camera uiCamera;               // Assign the camera used by your Canvas

    void Start()                            // Add all packages to a list to randomise spawn
    {
        packageList.Add(newPackage1);
        packageList.Add(newPackage2);
        packageList.Add(newPackage3);
    }


    public void DropPackage()
    {
        if (spawnArea == null || uiCamera == null) return;

        // Get the world corners of the RectTransform
        Vector3[] corners = new Vector3[4];
        spawnArea.GetWorldCorners(corners);

        // Left = corners[0], Right = corners[3]
        float leftX = corners[0].x;
        float rightX = corners[3].x;

        // Pick a random X position between left and right
        float randomX = Random.Range(leftX, rightX);

        // Y spawn position slightly above top edge
        float topY = corners[1].y;
        float spawnY = topY + spawnHeight;

        // Set spawn Z in front of camera (usually 0 for 2D)
        float spawnZ = 0f;

        Vector3 spawnPosition = new Vector3(randomX, spawnY, spawnZ);
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        // Chooses a random package from the prefab index

        int packageIndex = Random.Range(0, packageList.Count);
        Instantiate(packageList[packageIndex], spawnPosition, randomRotation);
    }

}
