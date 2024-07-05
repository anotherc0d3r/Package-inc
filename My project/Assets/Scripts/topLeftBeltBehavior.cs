using UnityEngine;
using System.Collections;

public class TopLeftBeltBehavior : BeltBehavior
{
    // Use this for initialisation
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
                Vector2 itemPoint = new Vector2(itemBounds.min.x, itemBounds.min.y);

                // Always move the item if it is exactly or more on top of the collider
            }
        }
    }
}