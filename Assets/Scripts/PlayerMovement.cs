using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Vector4 bounds;

    [SerializeField]
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 movementVector = new Vector2();

        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");

        movementVector *= speed;
        Vector3 pos = transform.position;

        if (transform.position.y > bounds.z && movementVector.y > 0)
        {

            movementVector.y = 0;
        }
        else if (transform.position.y < bounds.w && movementVector.y < 0)
        {
            movementVector.y = 0;
        }

        if (transform.position.x > bounds.x && movementVector.x > 0)
        {
            movementVector.x = 0;
        }
        else if (transform.position.x < bounds.y && movementVector.x < 0)
        {
            movementVector.x = 0;
        }

        //if (transform.position.x > bounds.x)
        //{
        //    pos.x = bounds.x;
        //}
        //else if (transform.position.x < bounds.y)
        //{
        //    pos.x = bounds.y;
        //}

        //if (transform.position.y > bounds.z)
        //{
        //    pos.y = bounds.z;
        //}
        //else if (transform.position.y < bounds.w)
        //{
        //    pos.y = bounds.w;
        //}

        body.velocity = movementVector;
        transform.position = pos;
    }
}
