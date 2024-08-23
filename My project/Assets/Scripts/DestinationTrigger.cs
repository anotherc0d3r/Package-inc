using UnityEngine;

public class DestinationTrigger : MonoBehaviour
{
    public Sprite correctPackageSprite;  // The correct sprite for this destination
    public int scoreIncrement = 10;      // Score to add when the correct package arrives
    private int score = 0;               // The player's current score

 /*   void OnTriggerEnter2D(Collider2D collision)
    {
        {
    Debug.Log("Collision detected with: " + collision.gameObject.name);
}
        if (collision.gameObject.tag == "item")
        {
            SpriteRenderer packageRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

            if (packageRenderer != null)
            {
                // Check if the package sprite matches the correct sprite
                if (packageRenderer.sprite == correctPackageSprite)
                {
                    score += scoreIncrement;
                    Debug.Log("Correct package delivered! Score: " + score);
                }
                else
                {
                    Debug.Log("Incorrect package delivered.");
                }

                // Optionally destroy the package after scoring
                Destroy(collision.gameObject);
            }
        }
    }
} */


void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "item")
    {
        SpriteRenderer packageRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        
        if (packageRenderer != null)
        {
            Debug.Log("Package sprite detected: " + packageRenderer.sprite.name);
            Debug.Log("Expected sprite: " + correctPackageSprite.name);

if (packageRenderer.sprite.name == correctPackageSprite.name)
{
    score += scoreIncrement;
    Debug.Log("Correct package delivered! Score: " + score);
}
else
{
    Debug.Log("Incorrect package delivered.");
}

            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("SpriteRenderer not found on package.");
        }
    }
}
}