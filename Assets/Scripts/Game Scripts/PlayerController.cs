using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//TODO Remove serialization after testing.
	[SerializeField] private bool inAir = false;	//toggle for when player is mid-jump.
	[SerializeField] private bool sliding = false;	//toggle for while player is mid-slide
	
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

	public void Jump ()
	{
		if (!inAir)
		{
			rb.AddForce( new Vector2( 0, thePlayer.GetJump() ) ); //applies jump force in upward direction
			inAir = true; //mark player as midair
		}
		else
		{
			//do nothing
		}
	}
	
	public void Slide ()
	{
		if (!sliding)
		{
			//TODO create slide functionality
		}
		else
		{
			//do nothing
		}
	}
	
	public void LandAlready () //public function that allows ground checker to remove mid-air flag
	{
		inAir = false;
	}
}
