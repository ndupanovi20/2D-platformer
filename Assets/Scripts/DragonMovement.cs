using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float verticalRange = 3.0f;
    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + verticalRange)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            if (transform.position.y <= startPosition.y - verticalRange)
            {
                movingUp = true;
            }
        }
    }
}
