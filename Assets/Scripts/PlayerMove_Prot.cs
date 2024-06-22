using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Prot : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = true; // Postavljamo na true ako igraè na poèetku gleda desno
    public int playerJumpPower = 300;
    private float moveX;
    private float moveY;

    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove();

        // Pomeranje i rotacija kamere zajedno s karakterom
        if (Camera.main != null)
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }

        // Ažuriramo animator sa yVelocity za skakanje
        animator.SetFloat("yVelocity", rb.velocity.y);
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

        // Ažuriramo animator parametre
        animator.SetBool("isWalking", moveX != 0);
        animator.SetBool("isJumping", !Mathf.Approximately(rb.velocity.y, 0));
    }

    void Jump()
    {
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
