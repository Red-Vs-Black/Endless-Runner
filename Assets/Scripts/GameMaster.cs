using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

	//private, inspector variables
	[SerializeField] float gameSpeed = 1.0f; //holder for current object speed, determines inital speed of startup
	[SerializeField] float acceleration = 0.1f; //amount speed is increased per update

	void Update ()
	{
		gameSpeed += acceleration; //increment object speed by acceleration
	}

	public float Speed ()
	{
		return gameSpeed; //Getter used for setting the speed of all objects
	}

}
