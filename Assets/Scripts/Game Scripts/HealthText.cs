using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

	Player thePlayer; //holder for gamemaster
	Text text; //holder for ui text
	
	private string startText; //holder for label set in inspector
	
	void Start () {
		thePlayer = FindObjectOfType<Player> (); //assign gamemaster to holder
		text = GetComponent<Text> (); //assign ui text to holder
		startText = text.text;	//copy label text to holder
	}
	
	void Update () {
		text.text = "" + startText + thePlayer.GetHealth (); //display label and speed value
	}
}
