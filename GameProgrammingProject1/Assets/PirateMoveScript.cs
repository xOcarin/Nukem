using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateMoveScript : MonoBehaviour
{
    public float moveSpeed = 2.0f; 
    public float leftLimit = -1.0f; 
    public float rightLimit = 1.0f; 

    private int direction = 1; 
    
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        float newXPosition = transform.position.x + (moveSpeed * direction * Time.deltaTime);
        
        if (newXPosition < leftLimit)
        {
            direction = 1; 
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        else if (newXPosition > rightLimit)
        {
            direction = -1; 
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }

        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}

