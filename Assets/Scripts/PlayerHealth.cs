﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -7)
        {
            Die();
        }
    }

    void Die()
    { 
        //reset game
        SceneManager.LoadScene("GameOverScreen");
    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }
}
