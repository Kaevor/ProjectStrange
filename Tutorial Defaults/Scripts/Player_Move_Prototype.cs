using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prototype : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public bool touchingItem;
    public bool foundItem;
    public UnityEngine.Object item;


    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRayCast();
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Destroy(item);
            foundItem = false;
        }
        //Animations
        //Player Direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true) {
            FlipPlayer();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    
    void Jump()
    {
        //Jumping Code
        if (isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
            isGrounded = false;
        }
    }

    void FlipPlayer()
    {
        //Flip Character Sprite
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnTriggerEnter2D (Collider2D trig)
    {
        foundItem = true;
        item = trig.gameObject;
    }

    void OnTriggerExit2D(Collider2D trig)
    {
        foundItem = false;
        item = null;
    }

    void PlayerRayCast()
    {
        //casts a ray down to find out what is below the player
        RaycastHit2D dirDown = Physics2D.Raycast(transform.position, Vector2.down);
        RaycastHit2D dirRight = Physics2D.Raycast(transform.position, Vector2.right);
        RaycastHit2D dirLeft = Physics2D.Raycast(transform.position, Vector2.left);
        //if standing on enemy top you hop and destroy the enemy
        if (dirDown.distance < 0.9f && dirDown.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            Destroy(dirDown.collider.gameObject);
        }
        //if touching something thats not an enemy then you can jump
        if (dirDown.distance < 0.9f && dirDown.collider.tag != "Enemy")
        {
            isGrounded = true;
        }
        //if standing on an item and you press "Fire1" you destroy/pick up the item
        if (dirDown.distance < 0.9f && dirDown.collider.tag == "Item" && Input.GetButtonDown("Fire1"))
        {
            Destroy(dirDown.collider.gameObject);
        }
    }
}
