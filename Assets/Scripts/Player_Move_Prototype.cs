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
    public int damage = 1;
    public Animator animator;


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRayCast();
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal")*0.5f;
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
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
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void FlipPlayer()
    {
        //Flip Character Sprite
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void PlayerRayCast()
    {
        //casts a ray down to find out what is below the player
        RaycastHit2D dirDown = Physics2D.Raycast(transform.position, Vector2.down);
        RaycastHit2D dirRight = Physics2D.Raycast(transform.position, Vector2.right);
        RaycastHit2D dirLeft = Physics2D.Raycast(transform.position, Vector2.left);
        //if standing on enemy top you hop and destroy the enemy
        if (dirDown.collider != null && dirDown.distance < 0.9f && dirDown.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1500);
            dirDown.collider.gameObject.GetComponent<EnemyHealth>().Health -= damage;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
