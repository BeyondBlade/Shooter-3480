using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private float screenHalfHeightInWorldUnits;
    private float screenHalfWidthInWorldUnits;

    void Start()
    {
        float halfPlayerHeight = transform.localScale.y / 2;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        screenHalfWidthInWorldUnits = Camera.main.aspect * screenHalfHeightInWorldUnits;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(inputX, inputY, 0) * speed * Time.deltaTime;

        transform.position += move;

        // Constrain player movement to the bottom half of the screen
        float clampedY = Mathf.Clamp(transform.position.y, -screenHalfHeightInWorldUnits, 0);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        // Wrap around horizontally
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector3(screenHalfWidthInWorldUnits, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector3(-screenHalfWidthInWorldUnits, transform.position.y, transform.position.z);
        }
    }
}
