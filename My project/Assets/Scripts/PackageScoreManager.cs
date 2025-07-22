using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public Sprite correctSprite;  // The correct sprite for this destination
//    public string correctPackage2;  // Used for fragile packages, of multiple colours
//    public string correctPackage3;  // Used for fragile packages, of multiple colours
    public int scoreIncrement = 1;      // The amount to increment the score
    public ScoreManager scoreManager;    // Reference to the ScoreManager

    void OnTriggerEnter2D(Collider2D collision)
    {
   //     Debug.Log("collision");
        if (collision.gameObject.tag == "Item")
        {
            SpriteRenderer packageRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

            if (packageRenderer != null)
            {

                if (packageRenderer.sprite == correctSprite) //|| packageRenderer.sprite.name == correctPackage2 || packageRenderer.sprite.name == correctPackage3)
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

