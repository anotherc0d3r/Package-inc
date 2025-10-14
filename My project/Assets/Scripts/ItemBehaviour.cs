using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Sprite newSprite;  // The sprite to switch to
    private Sprite originalSprite;  // The original sprite
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer
    // Speed
    private float _speed = 1;

    public float speed
    {
        set { this._speed = value; }
        get { return this._speed; }
    }

    private Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component
        originalSprite = spriteRenderer.sprite;  // Store the original sprite
    }

    void OnMouseDown()
    {
        if (newSprite != null)
        {
            //  spriteRenderer.sprite = newSprite;
            if (spriteRenderer.sprite == originalSprite)
            {
                audioManager.instance.PlaySFX(audioManager.instance.PackageOpened);
                spriteRenderer.sprite = newSprite;
            }
        /*    else
            {
                spriteRenderer.sprite = originalSprite;
            }*/
        }
    }
    void Update()
    {
        if (moveDirection != Vector2.zero)
        {
            transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
        }
    }

    // Move left
    public void MoveLeft()
    {
        moveDirection = Vector2.left;
    }

    // Move right
    public void MoveRight()
    {
        moveDirection = Vector2.right;
    }

    // Move down
    public void MoveDown()
    {
        moveDirection = Vector2.down;
    }

    // Move up
    public void MoveUp()
    {
        moveDirection = Vector2.up;
    }

    public void Stop()
    {
        moveDirection = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.Item)
        {
            Debug.Log("TRIGGEER ENTER 2D: " + collision.gameObject.name);
        }
    }
}
