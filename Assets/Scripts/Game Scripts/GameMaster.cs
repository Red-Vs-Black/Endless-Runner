using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	Player thePlayer; //reference for the player script
	public GameObject deathCanvas; //reference for the game over text
	
	//inspector variables
	[Tooltip ("Initial Game Speed")] [SerializeField] float gameSpeed = 1.0f;
	[Tooltip ("How often should the player's score increase")] [SerializeField] float scoreTime = 1f;
	
	[Header ("Accelerator Mode")]
	[Tooltip ("Toggle passive game acceleration")] [SerializeField] bool enableAcceleration = true;
	[Tooltip ("Speed Increase per Update")] [SerializeField] float acceleration = 0.1f;

	//hidden variables
	private int score = 0; //current score earned by player
	private float scoreTimer = 0f; 
	private float distance = 0f; //current distance travelled by player
	private int floor = 0; //current floor player is on
	private float curGameSpeed; //holder for current object speed, determines inital speed of startup

	void Start ()
	{
		curGameSpeed = gameSpeed; //save initial game speed
		thePlayer = FindObjectOfType<Player> (); //populate player reference
	}
	
	void Update ()
	{
		if (enableAcceleration)
		{
			curGameSpeed += acceleration; //increment object speed by acceleration
		}
		
		scoreTimer += Time.deltaTime; //increment time in real time

		if(scoreTimer >= scoreTime) //when timer hits the right time
		{
			score += 1 * Mathf.Abs(floor); //increment score by floor number
			scoreTimer = 0f; //reset timer
		}
	}
	
	public void ModSpeed (float mod) //function to change the game speed
	{
		curGameSpeed += mod;
	}
	
	public void Stop () //function to stop the game.
	{
		curGameSpeed = 0f;
	}
	
	public float Speed ()
	{
		float absSpeed; //temp variable for display speed

		absSpeed = Mathf.Round(curGameSpeed); //rounds off speed to avoid display errors
		return absSpeed; //Getter used for setting the speed of all objects
	}

	public int Score ()
	{
		return score; //getter used for updating score display
	}

	public float Distance ()
	{
		return distance; //getter used for updating distance display
	}
	
	public int Floor ()
	{
		return floor;
	}
	
	public void Restart ()
	{
		deathCanvas.SetActive (false); //hide gameover text
		//TODO delete all non-player entities
		thePlayer.gameObject.SetActive (true); //restore the player
		thePlayer.ResetHealth (); //fill health to full
		thePlayer.ResetPosition (); //send player back to default position
		curGameSpeed = gameSpeed; //reset game speed
	}
}
