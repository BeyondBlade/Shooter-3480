using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementType2 : MonoBehaviour
{
    public float speed = 3f;
    public float amplitude = 2f;
    public float frequency = 1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        // Move in a sine wave pattern
        float x = startPosition.x + Mathf.Sin(Time.time * frequency) * amplitude;
        float y = startPosition.y - speed * Time.deltaTime;
        transform.position = new Vector3(x, y, startPosition.z);
    }
}
