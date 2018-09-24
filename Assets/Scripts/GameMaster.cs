using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

	//inspector variables
	[SerializeField] float gameSpeed = 1.0f; //holder for current object speed, determines inital speed of startup
	[SerializeField] float acceleration = 0.1f; //amount speed is increased per update
	[SerializeField] float scoreTime = 1f; //timer variable for updating score

	//hidden variables
	private int score = 0; //current score earned by player
	private float scoreTimer = 0f; 
	private float distance = 0f; //current distance travelled by player
	private int floor = 1; //current floor player is on

	void Update ()
	{
		gameSpeed += acceleration; //increment object speed by acceleration
		scoreTimer += Time.deltaTime; //increment time in real time

		if(scoreTimer >= scoreTime) //when timer hits the right time
		{
			score += 1 * Mathf.Abs(floor); //increment score by floor number
			scoreTimer = 0f; //reset timer
		}
	}

	public float Speed ()
	{
		float absSpeed; //temp variable for display speed

		absSpeed = Mathf.Round(gameSpeed); //rounds off speed to avoid display errors
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
}
