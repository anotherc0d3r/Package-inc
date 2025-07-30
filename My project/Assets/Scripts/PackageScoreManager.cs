using UnityEngine;
using System.Collections.Generic;





public class PackageManager : MonoBehaviour
{
    //   public Sprite correctSprite;  // The correct sprite for this destination
    public List<Sprite> correctSprites = new List<Sprite>(); // allows for multiple correct sprites
    public int scoreIncrement = 1; // How much to add for correct deliveries

    public ScoreManager scoreManager;            // Handles score shown to player
    public packageSpawnerScript1 spawnerScript;  // Reference to spawner script to track ALL deliveries
    audioManager audioManager;


    private void Awake()
    {
       // audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
        audioManager = audioManager.instance;

    }

    void Start()
    {
        if (spawnerScript == null)
        {
            spawnerScript = FindObjectOfType<packageSpawnerScript1>();

            if (spawnerScript == null)
            {
      //          Debug.LogError("SpawnerScript not found in scene!");
            }
            else
            {
       //         Debug.Log("SpawnerScript auto-assigned successfully.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            SpriteRenderer packageRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

            // ✅ ALWAYS notify the spawner that a package has been delivered
            if (spawnerScript != null)
            {
                spawnerScript.NotifyPackageDelivered();  // NEW METHOD IN SPAWNER
                audioManager.PlaySFX(audioManager.packageThud); //PLay sound effect
        //        Debug.Log("Package delivered!");
            }
            else
            {
     //           Debug.LogWarning("SpawnerScript reference is missing.");
            }

            // ✅ Check for score if correct
            if /*(packageRenderer != null && packageRenderer.sprite == correctSprite)*/
            (packageRenderer != null && correctSprites.Contains(packageRenderer.sprite))

            {
                scoreManager.AddScore(scoreIncrement);
            //    Debug.Log("Correct package delivered! Score: " + scoreManager.score);
            }
            else
            {
         //       Debug.Log("Incorrect package delivered.");
            }

            Destroy(collision.gameObject);
        }
    }
}

