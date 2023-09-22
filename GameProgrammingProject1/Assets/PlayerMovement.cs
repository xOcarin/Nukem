using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool upPressed = false;
    bool downPressed = false;
    bool leftPressed = false;
    bool rightPressed = false;
    Rigidbody2D rb;
    public float moveForce = 1f;
    Vector3 originalScale;
    //real

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightPressed = true;
        }

        // Detect when keys are released
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            upPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            downPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftPressed = false;
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rightPressed = false;
            transform.localScale = originalScale;
        }
    }

    private void FixedUpdate()
    {
        // Apply continuous force while keys are held down
        if (upPressed)
        {
            rb.AddForce(new Vector2(0f, moveForce), ForceMode2D.Force);
        }
        if (downPressed)
        {
            rb.AddForce(new Vector2(0f, -moveForce), ForceMode2D.Force);
        }
        if (leftPressed)
        {
            rb.AddForce(new Vector2(-moveForce, 0f), ForceMode2D.Force);
        }
        if (rightPressed)
        {
            rb.AddForce(new Vector2(moveForce, 0f), ForceMode2D.Force);
        }
    }
}
