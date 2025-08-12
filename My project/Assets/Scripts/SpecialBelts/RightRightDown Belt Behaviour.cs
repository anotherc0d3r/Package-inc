using UnityEngine;

public class RightRightDownBeltBehaviour : MonoBehaviour
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
                    itemBehaviour.MoveRight();

                }
                else
                {
                    // Move right then down
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
            }
        }
    }
}

/*
using UnityEngine;

public class RightRightDownBeltBehaviour : MonoBehaviour
{
    public Sprite newSprite;  // The sprite to switch to
    private Sprite originalSprite;  // The original sprite
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
        originalSprite = spriteRenderer.sprite;  
    }

    void OnMouseDown()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 size = bounds.size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, size, 0);

        bool packageOnBelt = false;

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == Tags.Item)
            {
                packageOnBelt = true;
                break;
            }
        }

        if (!packageOnBelt && spriteRenderer != null)
        {
            spriteRenderer.sprite = (spriteRenderer.sprite == originalSprite) ? newSprite : originalSprite;
        }
    }

    void Update()
    {
        WatchForItem();
    }

    private void WatchForItem()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 size = bounds.size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, size, 0);

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == Tags.Item)
            {
                Transform item = collider.transform;
                Bounds itemBounds = item.GetComponent<Collider2D>().bounds;
                Vector2 itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                // Handle ItemBehaviour
                ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                if (itemBehaviour != null)
                {
                    itemBehaviour.speed = 1f;
                    MoveItem(itemBehaviour, bounds, itemPoint, item.position.x);
                }

                // Handle ChangingItemBehaviour
                ChangingItemBehaviour changingItem = item.GetComponent<ChangingItemBehaviour>();
                if (changingItem != null)
                {
                    changingItem.speed = 1f;
                    MoveItem(changingItem, bounds, itemPoint, item.position.x);
                }
            }
        }
    }

    private void MoveItem(dynamic behaviour, Bounds bounds, Vector2 itemPoint, float itemPosX)
    {
        if (!bounds.Contains(itemPoint))
            return;

        if (spriteRenderer.sprite == originalSprite)
        {
            behaviour.MoveRight();
        }
        else
        {
            if (transform.position.x - itemPosX > 0)
            {
                behaviour.MoveRight();
            }
            else
            {
                behaviour.MoveDown();
            }
        }
    }
}
*/