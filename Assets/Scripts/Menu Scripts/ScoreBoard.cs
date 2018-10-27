using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] Text[] scoreDisplays;

    void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey (i+"HScore"))
            {
                scoreDisplays[i].text = "" + PlayerPrefs.GetInt (i+"HScore");
            }
            else
            {
                Debug.Log ("PlayerPrefs." + i +"HScore contains a null value.");
            }
        }
    }
}
