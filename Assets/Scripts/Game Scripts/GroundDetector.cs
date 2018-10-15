using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour {

	PlayerController thePlayer; //holder for player control script
	
	void Start ()
	{
		thePlayer = FindObjectOfType<PlayerController> (); //on start, find player control script
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Ground")	//on contact, check if landed on ground
		{
			thePlayer.LandAlready ();	// if ground detected, remove mid-air flag to allow jumping again
		}
	}
	
}
