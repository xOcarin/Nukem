using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NullMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveForce = 1f;
    public bool left = false;
    public bool right = false;
    
    private Vector3 initialScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 currentPosition = transform.position;
        initialScale = transform.localScale;

        if (currentPosition.x > 0)
        {
            right = true;
        }
        else
        {
            left = true;
        }
    }

    void Update()
    {
        if (right == true)
        {
            Vector2 force = new Vector2(-moveForce, 0f);
            rb.AddForce(force);
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else
        {
            Vector2 force = new Vector2(+moveForce, 0f);
            rb.AddForce(force);
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
    }
}
