using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	//private, inspector variables
	[Header("Player Settings")]
	[Tooltip("Player's max HP")] [SerializeField] int maxHealth = 10;
	[Tooltip("Upward force of jump")] [SerializeField] float jumpPower = 10f;
	[Tooltip("Duration of slide action")] [SerializeField] float slideLength = 1f;

	//private, hidden variables
	private int curHealth; //player current hp
	private Vector3 startPosition; //holder for starting position

	public GameObject deathCanvas; //reference to game over text
	GameMaster gm; //reference to the gm
	
	//getters and setters
	public int GetHealth () //reports player current hp when called
	{
		return curHealth;
	}

	public void ModHealth (int mod) //modifies player hp by mod
	{
		curHealth += mod;

		if (curHealth > maxHealth) //check for overheal
		{
			curHealth = maxHealth; //prevent overheal
		}
		else if (curHealth <= 0) //check for death
		{
			Death ();
		}
	}

	public void ResetHealth ()
	{
		curHealth = maxHealth; //refill health to full
	}
	
	public float GetJump () //reports jump force when called
	{
		return jumpPower;
	}

	public void SetJump (float mod) //modifies jump force by mod
	{
		jumpPower += mod; //TODO remove if unused
	}

	public void ResetPosition () //function to return player to initial position
	{
		transform.position = startPosition;
	}
	
	void Start ()
	{
		gm = FindObjectOfType<GameMaster> (); //populate gm reference
		curHealth = maxHealth; //initializes player health at max
		startPosition = transform.position; //save initial position
	}

	void Death ()
	{
		deathCanvas.SetActive (true); //display game over text
		gameObject.SetActive (false); //delete the player
		gm.Stop(); //stop game
	}
	
}
