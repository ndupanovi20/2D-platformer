using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Prot : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 600;
    private float moveX;


    void Start()
    {

    }

    // Update is called once per frame
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

        // ANIMATIONS

        // PLAYER DIRECTION
        if (moveX > 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX < 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        // JUMPING CODE
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Postavljamo Z-rotaciju na 0
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); // Resetujemo brzinu pri skoku da bismo izbegli neželjene efekte
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
