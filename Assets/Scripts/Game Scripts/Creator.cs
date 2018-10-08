using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

	[SerializeField] GameObject[] obstacles;	//array of spawnable objects
	[SerializeField] float spawnTime = 1f;	//time delay between new spawns
	private float tracker = 0f;	//holding variable for time since last spawn
	
	void Update ()
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
