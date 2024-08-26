using UnityEngine;

public class DownDownLeftBeltBehaviour : MonoBehaviour
{
    public Sprite newSprite;  // The sprite to switch to
    private Sprite originalSprite;  // The original sprite
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component
        originalSprite = spriteRenderer.sprite;  // Store the original sprite
    }

    void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            if (spriteRenderer.sprite == originalSprite)
            {
                spriteRenderer.sprite = newSprite;
            }
            else
            {
                spriteRenderer.sprite = originalSprite;
            }
        }
    }

    void Update()
    {
        WatchForItem();
    }

    private void WatchForItem()
    {
        Bounds bounds = this.transform.GetComponent<Collider2D>().bounds;
        Vector2 size = bounds.size;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(this.transform.position, size, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == Tags.Item)
            {
                Transform item = collider.GetComponent<Transform>();
                Bounds itemBounds = item.GetComponent<Collider2D>().bounds;
                Vector2 itemPoint;

                ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                itemBehaviour.speed = 1f;

                if (spriteRenderer.sprite == originalSprite)
                {
                    // Move right
                    itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                    if (!bounds.Contains(itemPoint))
                    {
                        continue;
                    }
                    itemBehaviour.MoveDown();

                }
                else
                {
                    // Move right then down
                    itemPoint = new Vector2(itemBounds.max.x, itemBounds.max.y);

                    if (!bounds.Contains(itemPoint))
                    {
                        continue;
                    }

                    if (this.transform.position.y - item.position.y < 0)
                    {
                        itemBehaviour.MoveDown();
                    }
                    else
                    {
                        itemBehaviour.MoveLeft();
                    }
                }
            }
        }
    }
}
