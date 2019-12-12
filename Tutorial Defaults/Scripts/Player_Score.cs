using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    public float timeTaken = 0;
    public int playerScore = 0;
    public int topScore = 1000;
    public bool finished = false;
    public GameObject timeUsedUI;
    public GameObject playerScoreUI;

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            //Increases time to record how long you take
            timeTaken += Time.deltaTime;
            Debug.Log(timeTaken);
        }
        timeUsedUI.gameObject.GetComponent<Text>().text = ("Time: " + (int)timeTaken);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + (int)playerScore);
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        
        if (trig.gameObject.tag == "Crystal")
        {
            //Get score and remove object that gave the score
            playerScore += 100;
            Destroy(trig.gameObject);
        }
        if (trig.gameObject.tag == "Level End") {
            //if we reach the end of the level
            CountScore();
        }
        
    }

    void CountScore()
    {
        //Stops the counter and gives us our final score
        finished = true;
        playerScore = (topScore - (int)(timeTaken)) + playerScore;
        Debug.Log("You have the score " + playerScore);

    }

}
