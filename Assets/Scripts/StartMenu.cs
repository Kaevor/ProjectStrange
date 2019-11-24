using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button playButton, exitButton;
    void Start()
    {
        //tells button to call 'TaskOnClick' method when clicked
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("ProjectStrange");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
