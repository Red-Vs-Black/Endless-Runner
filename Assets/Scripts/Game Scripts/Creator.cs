using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

	[Tooltip ("What floor is this spawner for?")] [SerializeField] int activeLevel = 0;
	[Tooltip ("Start spawnning when the player is this many floors away.")] [SerializeField] int spawnPadding = 1;
	[Tooltip ("Time between spawns.")] [SerializeField] float spawnTime = 1f;
	[SerializeField] GameObject[] obstacles;	//array of spawnable objects
	
	private float tracker = 0f;	//holding variable for time since last spawn
	GameMaster gm; //reference to the gm
	
	void Start ()
	{
		gm = FindObjectOfType<GameMaster> (); //populate gm reference
	}
	
	void Update ()
	{
		if (gm.Speed () > 0)
		{
			if (gm.Floor () > (activeLevel + spawnPadding) || gm.Floor () < (activeLevel - spawnPadding)) //if player is not within range to start spawning
			{
				tracker = 0f; //reset the timer
			}
			
			else //when player is within range
			{
				tracker += Time.deltaTime;	//increment the tracker by time passed between frames
				
				if (tracker >= spawnTime)	//if enough time has passed
				{
					int spawnTarget = Random.Range(0, obstacles.Length);	//determine a random object to spawn
					
					Instantiate(obstacles[spawnTarget], transform.position, transform.rotation); //spawn the object at the creator
					tracker = 0f;	//reset the timer
				}
			}
		}
		else
		{
			tracker = 0f;
		}
	}
}
