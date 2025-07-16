using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public Sprite correctPackageSprite1;  // The correct sprite for this destination
    public Sprite correctPackageSprite2;  // Used for fragile packages, of multiple colours
    public Sprite correctPackageSprite3;  // Used for fragile packages, of multiple colours
    public int scoreIncrement = 1;      // The amount to increment the score
    public ScoreManager scoreManager;    // Reference to the ScoreManager

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            SpriteRenderer packageRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

            if (packageRenderer != null)
            {
                if (packageRenderer.sprite == correctPackageSprite1 || correctPackageSprite2 || correctPackageSprite3)
                {
                    scoreManager.AddScore(scoreIncrement);  // Update the score
                    Debug.Log("Correct package delivered! Score: " + scoreManager.score);
                }
                else
                {
                    Debug.Log("Incorrect package delivered.");
                }

                // Optionally, destroy the package after processing
                Destroy(collision.gameObject);
            }
        }
    }
}

