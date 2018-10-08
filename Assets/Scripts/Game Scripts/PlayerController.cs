using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//component holders
	GameMaster gm; //TODO remove if unused
	Player thePlayer;
	Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		gm = FindObjectOfType<GameMaster>(); //populate with gm script
		thePlayer = GetComponent<Player>(); //populate with player script
		rb = GetComponent<Rigidbody2D>(); //populate with Rigidbody component
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) //if spacebar is pressed: jump!
		{
			Jump();
		}
	}

	void Jump ()
	{
		rb.AddForce( new Vector2( 0, thePlayer.GetJump() ) ); //applies jump force in upward direction
		//TODO create ground check to prevent mid-air jumps
	}
}
