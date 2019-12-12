using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("ProjectStrange");
        }
    }
}
