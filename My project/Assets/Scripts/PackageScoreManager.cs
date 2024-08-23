using UnityEngine;

public class PackageScoreManager : MonoBehaviour
{
    public int score = 0;  // The player's score
    public Color correctColor;  // The correct color for this destination

    // This function will be called when a package reaches the destination
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            SpriteRenderer packageRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            
            // Check if the package color matches the destination color
            if (packageRenderer != null && packageRenderer.color == correctColor)
            {
                // Add to the score if the color matches
                score += 10;
                Debug.Log("Correct package delivered! Score: " + score);
            }
            else
            {
                // No score added if the color does not match
                Debug.Log("Incorrect package delivered.");
            }

            // Optionally destroy or disable the package after scoring
            Destroy(collision.gameObject);
        }
    }
}
