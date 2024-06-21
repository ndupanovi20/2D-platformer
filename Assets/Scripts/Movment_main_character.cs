using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Prot : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false; // Postavljamo na false da igraè na poèetku gleda levo
    public int playerJumpPower = 600;
    private float moveX;
    private float moveY;

    void Start()
    {
        // Inicijalizujemo facingRight na false ako želimo da igraè na poèetku gleda levo
        facingRight = false;
    }

    void Update()
    {
        PlayerMove();

        // Pomeranje i rotacija kamere zajedno s karakterom
        if (Camera.main != null)
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }
    }

    void PlayerMove()
    {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        // PLAYER DIRECTION
        if (moveX > 0.0f && !facingRight)
        {
            FlipPlayer();
        }
        else if (moveX < 0.0f && facingRight)
        {
            FlipPlayer();
        }

        // PHYSICS
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);

        // MOVING VERTICALLY
        if (moveY != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveY * playerSpeed);
        }

        // JUMPING CODE
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) // Skakanje samo ako je igraè na zemlji
        {
            Jump();
        }

        // Postavljamo Z-rotaciju na 0
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, 0); // Resetujemo vertikalnu brzinu pri skoku da bismo izbegli neželjene efekte
        rb.AddForce(Vector2.up * playerJumpPower);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
