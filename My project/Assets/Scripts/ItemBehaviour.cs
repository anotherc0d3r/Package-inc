using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemBehaviour : MonoBehaviour
{

    // Speed
    private float_speed = 1;

    public float speed
    {
        set
        {
            this._speed = value;
        }
        get
        {
            return this._speed;
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    // Move left

    public void MoveLeft()
    {
        Vector3 nextPosition = new Vector3(
            this.transform.position.x - this.speed * Time.deltaTime,
            this.transform.position.y, 
            this.transform.position.z
        );
        this.transform.position = nextPosition;
    }

    // Move right

    public void MoveRight()
    {
        Vector3 nextPosition = new Vector3(
            this.transform.position.x + this.speed * Time.deltaTime,
            this.transform.position.y, 
            this.transform.position.z
        );
        this.transform.position = nextPosition;
    }

    // Move down

    public void MoveDown()
    {
        Vector3 nextPosition = new Vector3(
            this.transform.position.x,
            this.transform.position.y - this.speed * Time.deltaTime, 
            this.transform.position.z
        );
        this.transform.position = nextPosition;
    }

    // Move up
        public void MoveUp()
    {
        Vector3 nextPosition = new Vector3(
            this.transform.position.x,
            this.transform.position.y + this.speed * Time.deltaTime, 
            this.transform.position.z
        );
        this.transform.position = nextPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.Item)
        {
            Debug.Log("TRIGGEER ENTER 2D: " + collision.gameObject.name);
        }
    }
}