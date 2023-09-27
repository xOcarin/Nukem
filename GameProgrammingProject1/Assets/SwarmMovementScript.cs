using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovementScript : MonoBehaviour
{
    public float radius = 2.0f; // Radius of the circular path
    public float angularSpeed = 90.0f; // Angular speed in degrees per second

    private float angle = 0.0f;

    private void Start()
    {
        
    }

    void Update()
    {
        // Calculate the new position of the object in a circular path
        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

        // Update the object's position
        transform.position = new Vector3(x, y, transform.position.z);

        // Increment the angle based on the angular speed and time
        angle += angularSpeed * Time.deltaTime;

        // Wrap the angle around to keep it within 0 to 360 degrees
        if (angle >= 360.0f)
        {
            angle -= 360.0f;
        }
    }
}