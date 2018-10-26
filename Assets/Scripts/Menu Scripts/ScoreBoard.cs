using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public void AddScore (int score) //Add new score to scoreboard
    {
        int newScore;   //holder for latest score
        int oldScore;   //holder for old scores
        newScore = score;   //initialize newScore as the input score

        for (int i = 0; i < 10; i++)    //scoreboard will hold ten highest scores
        {
            if (PlayerPrefs.HasKey (i+"HScore"))    //if a score already exists in i place
            {
                if (PlayerPrefs.GetInt (i+"HScore") < newScore) //if newScore is higher that existing score in i place
                {
                    oldScore = PlayerPrefs.GetInt (i+"HScore"); //store existing score in oldScore
                    PlayerPrefs.SetInt (i+"HScore", newScore);  //record new score in old score's place
                    newScore = oldScore;    //store existing score in newScore for next loop
                }
            }
            else    //if i place is blank
            {
                PlayerPrefs.SetInt (i+"HScore", newScore);  //record newScore in i place
                newScore = 0;   //set newScore to 0 to fill remaining empty places
            }
        }
    }
}
