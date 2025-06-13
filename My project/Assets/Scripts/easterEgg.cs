using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public GameObject newPackage1;        // Assign your package prefab in Inspector
    public RectTransform spawnArea;       // Assign a UI canvas RectTransform (optional)

    public float spawnHeight = 6f;        // Default height if no canvas
    public float spawnRange = 5f;         // Range for random X if no canvas

    public void DropPackage()
    {
        Vector3 spawnPosition;

        if (spawnArea != null)
        {
            // Get a random point within the RectTransform area
            Vector2 localPoint = new Vector2(
                Random.Range(spawnArea.rect.xMin, spawnArea.rect.xMax),
                spawnArea.rect.yMax + 100f // Just above the top of the canvas
            );

            // Convert local canvas position to world position
            spawnPosition = spawnArea.TransformPoint(localPoint);
        }
        else
        {
            // Fallback position if no spawn area is set
            float randomX = Random.Range(-spawnRange, spawnRange);
            spawnPosition = new Vector3(randomX, spawnHeight); // Removed z = 0f
        }

        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        Instantiate(newPackage1, spawnPosition, randomRotation);
    }
}
