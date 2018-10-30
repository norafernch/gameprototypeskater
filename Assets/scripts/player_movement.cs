using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public int playerSpeed = 10;
    public bool facingRight = false;
    public int playerJumpPower = 1250;
    public float moveX;
    public bool isGrounded;


    // Update is called once per frame
    void Update ()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && isGrounded == true){
            Jump();
        }
        //animation
        //player direction
        if (moveX < 0.0f && facingRight){
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true) {
            FlipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump() {
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;

    }
    void FlipPlayer(){
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }

    void OnCollisionEnter2D (Collision2D col){
        Debug.Log("Player has collided with " + col.collider.name);
        isGrounded |= col.gameObject.tag == "ground";
    }
}
