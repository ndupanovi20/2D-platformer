using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float moveRange = 5.0f;
    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= startPosition.x + moveRange)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
            if (transform.position.x <= startPosition.x - moveRange)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
