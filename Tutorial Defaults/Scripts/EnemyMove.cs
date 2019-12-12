using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public int enemySpeed;
    public int xMoveDirection;
    public bool restart = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;
        if (hit.distance < 0.4f)
        {
            FlipEnemy();
        }
        EnemyRayCast();
    }

    void FlipEnemy()
    {
        if (xMoveDirection > 0)
        {
            xMoveDirection = -1;
        }
        else
        {
            xMoveDirection = 1;
        }
    }

    void EnemyRayCast()
    {
        //casts a ray down to find out what is below the player
        RaycastHit2D dirLeft = Physics2D.Raycast(transform.position, Vector2.left);
        RaycastHit2D dirRight = Physics2D.Raycast(transform.position, Vector2.right);

        //if standing on an item and you press "Fire1" you destroy/pick up the item
        if (dirRight.distance < 0.4f && dirRight.collider.tag == "Player")
        {
            Destroy(dirRight.collider.gameObject);
            GameOver();
        }
        if (dirLeft.distance < 0.4f && dirLeft.collider.tag == "Player")
        {
            Destroy(dirLeft.collider.gameObject);
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
