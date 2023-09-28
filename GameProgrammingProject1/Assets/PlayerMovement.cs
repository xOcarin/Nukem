using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // left as directions instead of wasd for directional clarity
    bool upPressed = false;
    bool downPressed = false;
    bool leftPressed = false;
    bool rightPressed = false;

    // Player Position
    public float xPos;
    public float yPos;

    Rigidbody2D rb;
    public float moveForce = 1f;
    Vector3 originalScale;

    public PlayerPointHandler handler; //Other script as an obj
    private bool pirateCooldown = false;

    private Animator anim;

    private bool isRunning;
    private bool isSleeping;

    public GameObject Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        originalScale = transform.localScale; // store scale so it doesnt size up
        handler = GetComponent<PlayerPointHandler>(); // init the component(the PlayerPointHandler Script)
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        xPos = Player.transform.position.x;     // grabs player position for spawning check
        yPos = Player.transform.position.y;     // grabs player position for spawning check
        //Debug.Log(xPos + " " + yPos);
        pirateCooldown = handler.pirateBool; //assigning bool from PlayerPointHandler every frame.
        if (pirateCooldown == false) 
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                upPressed = true;
                anim.SetBool("isRunning", true);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                downPressed = true;
                anim.SetBool("isRunning", true);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                leftPressed = true;
                anim.SetBool("isRunning", true);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rightPressed = true;
                anim.SetBool("isRunning", true);
                transform.eulerAngles = new Vector3(0, 0, 0);
            } 
        }
            
            // Detect when keys are released
            if (Input.GetKeyUp(KeyCode.W))
            {
                upPressed = false;
                anim.SetBool("isRunning", false);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                downPressed = false;
                anim.SetBool("isRunning", false);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                leftPressed = false;
                transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
                anim.SetBool("isRunning", false);
            }
            if (Input.GetKeyUp(KeyCode.D))
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