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

    public PlayerPointHandler handler; //Other script as an obj
    private bool pirateCooldown = false;

    private Animator anim;

    private bool isRunning;
    private bool isSleeping;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        originalScale = transform.localScale; // store scale so it doesnt size up
        handler = GetComponent<PlayerPointHandler>(); // init the component(the PlayerPointHandler Script)
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        pirateCooldown = handler.pirateBool; //assigning bool from PlayerPointHandler every frame.
        if (pirateCooldown == false) 
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                upPressed = true;
                anim.SetBool("isRunning", true);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                downPressed = true;
                anim.SetBool("isRunning", true);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftPressed = true;
                anim.SetBool("isRunning", true);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rightPressed = true;
                anim.SetBool("isRunning", true);
                transform.eulerAngles = new Vector3(0, 0, 0);
            } 
        }
            
            // Detect when keys are released
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                upPressed = false;
                anim.SetBool("isRunning", false);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                downPressed = false;
                anim.SetBool("isRunning", false);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                leftPressed = false;
                transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
                anim.SetBool("isRunning", false);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                rightPressed = false;
                transform.localScale = originalScale;
                anim.SetBool("isRunning", false);
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
