using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool paused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = TogglePaused();
        }
    }

    bool TogglePaused()
    {
        if(Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
            return (false);
        }
        else
        {
            Time.timeScale = 0.0f;
            return (true);
        }
    }
}
