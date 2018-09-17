using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	//private, inspector variables
	[SerializeField] int maxHealth = 10; //player max hp
	[SerializeField] float jumpPower = 10f; //determines upward force of jump

	//private, hidden variables
	private int curHealth; //player current hp

	//getters and setters
	public int GetHealth() //reports player current hp when called
	{
		return curHealth;
	}

	public void ModHealth(int mod) //modifies player hp by mod
	{
		curHealth += mod;

		if(curHealth > maxHealth) //check for overheal
		{
			curHealth = maxHealth; //prevent overheal
		}
		else if(curHealth <= 0) //check for death
		{
			//TODO write Death function
		}
	}

	public float GetJump() //reports jump force when called
	{
		return jumpPower;
	}

	public void SetJump(float mod) //modifies jump force by mod
	{
		jumpPower += mod; //TODO remove if unused
	}

	void Start()
	{
		curHealth = maxHealth; //initializes player health at max
	}

}
