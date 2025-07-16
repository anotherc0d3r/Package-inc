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

                ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                itemBehaviour.speed = 1f;

                if (spriteRenderer.sprite == originalSprite)
                {
                    // Move Down
                    itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                    if (!bounds.Contains(itemPoint))
                    {   
                               
                        continue;
                    }
                    itemBehaviour.MoveDown();

                }
                else
                {

                    Debug.Log("Switched to down-then-right movement");
                    // Move down then right
                    itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

 /*                   if (!bounds.Contains(itemPoint))
                    {
                         Debug.Log("Item not within bounds yet");
                        continue;
                    }
*/

                    if (item.position.y - this.transform.position.y > 0)
                    {
                        Debug.Log("Moving Down");
                        itemBehaviour.MoveDown();
                    }
                    else
                    {
                        Debug.Log("Moving Right");
                        itemBehaviour.MoveRight();
                    }
                }
            }
        }
    }
}

/*
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

                ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                itemBehaviour.speed = 1f;

                if (spriteRenderer.sprite == originalSprite)
                {
                    // Move Down
                    itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                    if (!bounds.Contains(itemPoint))
                    {
                        continue;
                    }
                    itemBehaviour.MoveDown();
                }
                else
                {
                    // Move down then right
                    itemPoint = new Vector2(itemBounds.min.x, itemBounds.max.y);

                    if (!bounds.Contains(itemPoint))
                    {
                        continue;
                    }

                    if ( item.position.y > this.transform.position.y - 0.1f)
                    {
                        Debug.Log("Item Y: " + item.position.y + " | Belt Y: " + this.transform.position.y);
                        itemBehaviour.MoveDown();
                    }
                    else
                    {
                        itemBehaviour.MoveRight();
                    }
                }
            }
        }
    }
}




using UnityEngine;

public class DownDownRightBeltBehaviour : MonoBehaviour
{
    public Sprite newSprite;
    private Sprite originalSprite;
    private SpriteRenderer spriteRenderer;

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

                if (!bounds.Contains(itemPoint)) continue;

                ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                itemBehaviour.speed = 1f;

                if (spriteRenderer.sprite == originalSprite)
                {
                    // Move Down (Original)
                    itemBehaviour.MoveDown();
                }
                else
                {
                    // Move Down then Right (New Sprite)
                    float distanceToBottom = Mathf.Abs(item.position.y - (transform.position.y - bounds.extents.y));

                    if (distanceToBottom > 0.05f)
                    {
                        // Still above bottom edge → move down
                        itemBehaviour.MoveDown();
                    }
                    else
                    {
                        // Reached bottom edge → move right
                        itemBehaviour.MoveRight();
                    }
                }
            }
        }
    }
}
*/