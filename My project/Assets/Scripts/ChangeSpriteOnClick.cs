using UnityEngine;

public class ChangeSpriteOnClick : MonoBehaviour
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
                    // RightDownBeltBehaviour logic (Original sprite: Move right, then down)
                    itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                    if (!bounds.Contains(itemPoint))
                    {
                        continue;
                    }

                    if (this.transform.position.x - item.position.x > 0)
                    {
                        itemBehaviour.MoveRight();
                    }
                    else
                    {
                        itemBehaviour.MoveDown();
                    }
                }
                else
                {
                    // RightUpBeltBehaviour logic (New sprite: Move right, then up)
                    itemPoint = new Vector2(itemBounds.min.x, itemBounds.min.y);

                    if (!bounds.Contains(itemPoint))
                    {
                        continue;
                    }

                    if (this.transform.position.x - item.position.x > 0)
                    {
                        itemBehaviour.MoveRight();
                    }
                    else
                    {
                        itemBehaviour.MoveUp();
                    }
                }
            }
        }
    }
}
