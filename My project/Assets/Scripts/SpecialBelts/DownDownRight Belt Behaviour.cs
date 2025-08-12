
using UnityEngine;

public class DownDownRightBeltBehaviour : MonoBehaviour
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
        // Check if there's a package on the belt
        Bounds bounds = this.transform.GetComponent<Collider2D>().bounds;
        Vector2 size = bounds.size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(this.transform.position, size, 0);

        bool packageOnBelt = false;

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == Tags.Item)
            {
                packageOnBelt = true;
                break;
            }
        }

        // If there's no package, allow sprite change
        if (!packageOnBelt && spriteRenderer != null)
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

                // Handle ItemBehaviour
                ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                if (itemBehaviour != null)
                {
                    itemBehaviour.speed = 1f;
                }

                // Handle ChangingItemBehaviour
                ChangingItemBehaviour changingItem = item.GetComponent<ChangingItemBehaviour>();
                if (changingItem != null)
                {
                    changingItem.speed = 1f;
                }

                if (spriteRenderer.sprite == originalSprite)
                {
                    // Move Down
                    itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                    if (!bounds.Contains(itemPoint))
                        continue;

                    if (itemBehaviour != null) itemBehaviour.MoveDown();
                    if (changingItem != null) changingItem.MoveDown();
                }
                else
                {
                    // Move Down then Right
                    itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                    if (item.position.y - this.transform.position.y > 0)
                    {
                        if (itemBehaviour != null) itemBehaviour.MoveDown();
                        if (changingItem != null) changingItem.MoveDown();
                    }
                    else
                    {
                        if (itemBehaviour != null) itemBehaviour.MoveRight();
                        if (changingItem != null) changingItem.MoveRight();
                    }
                }
            }
        }
    }
}