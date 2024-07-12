using UnityEngine;
using System.Collections;

public class BottomRightBeltBehaviour : BeltBehaviour
{    // Use this for initialisation
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once a frame
    protected override void Update()   
    {
        base.Update();
    }


    /** Summary
    Watch for the item on top of the belt
    move the items to the origin point and then downwards
    **/

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
                Vector2 itemPoint = new Vector2(itemBounds.max.x, itemBounds.max.y);

                // Always move the item if it is exactly or more on top of the collider
                if (!bounds.Contains(itemPoint)) 
                {
                    continue;
                }

                // Has the item reached the origin point?
                if (this.transform.position.y - item.position.y < 0)
                {
                    ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                    itemBehaviour.speed = 1f;
                    itemBehaviour.MoveDown();
                }

                //If the item has reached the origin point, move right
                else
                {
                    ItemBehaviour itemBehaviour = item.GetComponent<ItemBehaviour>();
                    itemBehaviour.speed = 1f;
                    itemBehaviour.MoveLeft();
                }
            }
        }
    }
}