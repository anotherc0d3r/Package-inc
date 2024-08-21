using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class TopRightBeltBehaviour : BeltBehaviour
{
    public Sprite newSprite;  // The sprite to switch to
    private Sprite originalSprite;  // The original sprite
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component
        originalSprite = spriteRenderer.sprite;  // Store the original sprite
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void WatchForItem()
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
                Vector2 itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                if (!bounds.Contains(itemPoint))
                {
                    continue;
                }

                ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                itemBehaviour.speed = 1f;

                // Move the item based on its position relative to the origin
                if (this.transform.position.x - item.position.x > 0)
                {
                    itemBehaviour.MoveRight();
                }
                else
                {
                    itemBehaviour.MoveDown();
                }
            }
        }
    }

    protected void MoveItemRightAndUp()
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
                Vector2 itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                if (!bounds.Contains(itemPoint))
                {
                    continue;
                }

                ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                itemBehaviour.speed = 1f;

                // Move the item based on its position relative to the origin
                if (this.transform.position.x - item.position.x < 0)
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

    void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            if (spriteRenderer.sprite == originalSprite)
            {
                spriteRenderer.sprite = newSprite;
                WatchForItem();  // Call WatchForItem when the sprite is changed to the new sprite
            }
            else
            {
                spriteRenderer.sprite = originalSprite;
                MoveItemRightAndUp();  // Call MoveItemRightAndUp when switching back to the original sprite
            }
        }
    }
} */