using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	GameMaster gm; //holder for gamemaster
	Text text; //holder for ui text
	
	private string startText; //holder for label set in inspector
	
	void Start () {
		gm = FindObjectOfType<GameMaster>(); //assign gamemaster to holder
		text = GetComponent<Text>(); //assign ui text to holder
		startText = text.text;	//copy label text to holder
	}
	
	void Update () {
		text.text = "" + startText + gm.Score(); //display label and score value
	}
}
