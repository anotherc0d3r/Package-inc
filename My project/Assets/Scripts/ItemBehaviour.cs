/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemBehaviour : MonoBehaviour
{

    // Speed
    private float _speed = 1;

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
            Debug.Log("TRIGGEER ENTER 2D: "+ collision.gameObject.name);
        }
    }
} */




/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemBehaviour : MonoBehaviour
{

    // Speed
    private float _speed = 1;

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
        Vector3 targetPosition = new Vector3(
            this.transform.position.x - 1f,
            this.transform.position.y,
            this.transform.position.z
        );
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            targetPosition,
            this.speed * Time.deltaTime
        );
    }

    // Move right
    public void MoveRight()
    {
        Vector3 targetPosition = new Vector3(
            this.transform.position.x + 1f,
            this.transform.position.y,
            this.transform.position.z
        );
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            targetPosition,
            this.speed * Time.deltaTime
        );
    }

    // Move down
    public void MoveDown()
    {
        Vector3 targetPosition = new Vector3(
            this.transform.position.x,
            this.transform.position.y - 1f,
            this.transform.position.z
        );
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            targetPosition,
            this.speed * Time.deltaTime
        );
    }

    // Move up
    public void MoveUp()
    {
        Vector3 targetPosition = new Vector3(
            this.transform.position.x,
            this.transform.position.y + 1f,
            this.transform.position.z
        );
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            targetPosition,
            this.speed * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.Item)
        {
            Debug.Log("TRIGGEER ENTER 2D: "+ collision.gameObject.name);
        }
    }
} */




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
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
