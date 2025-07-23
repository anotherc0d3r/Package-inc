/*using UnityEngine;

public class PackageManager : MonoBehaviour
{

    public int GetDeliveredCount()
{
    return packageDelivered;
}

    public Sprite correctSprite;  // The correct sprite for this destination
//    public string correctPackage2;  // Used for fragile packages, of multiple colours
//    public string correctPackage3;  // Used for fragile packages, of multiple colours
    public int scoreIncrement = 1;      // The amount to increment the score
    private int packageDelivered = 1;
    public ScoreManager scoreManager;    // Reference to the ScoreManager
    public packageSpawnerScript1 deliverManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
   //     Debug.Log("collision");
        if (collision.gameObject.tag == "Item")
        {
            SpriteRenderer packageRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

             deliverManager.AddScore(packageDelivered);
                Debug.Log("Delivered");


            if (packageRenderer != null)
            {
                if (packageRenderer.sprite == correctSprite)
                {
                    scoreManager.AddScore(scoreIncrement);  // Update the score
                    Debug.Log("Correct package delivered! Score: " + scoreManager.score);
                }
                else
                {
                    Debug.Log("Incorrect package delivered.");
                }

                // destroy the package after processing
                Destroy(collision.gameObject);
            }
        }
    }
}
*/



using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public Sprite correctSprite;  // The correct sprite for this destination
    public int scoreIncrement = 1; // How much to add for correct deliveries

    public ScoreManager scoreManager;            // Handles score shown to player
    public packageSpawnerScript1 spawnerScript;  // Reference to spawner script to track ALL deliveries

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            SpriteRenderer packageRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

            // ✅ ALWAYS notify the spawner that a package has been delivered
            if (spawnerScript != null)
            {
                spawnerScript.NotifyPackageDelivered();  // NEW METHOD IN SPAWNER
                Debug.Log("Package delivered!");
            }
            else
            {
                Debug.LogWarning("SpawnerScript reference is missing.");
            }

            // ✅ Check for score if correct
            if (packageRenderer != null && packageRenderer.sprite == correctSprite)
            {
                scoreManager.AddScore(scoreIncrement);
                Debug.Log("Correct package delivered! Score: " + scoreManager.score);
            }
            else
            {
                Debug.Log("Incorrect package delivered.");
            }

            Destroy(collision.gameObject);
        }
    }
}

