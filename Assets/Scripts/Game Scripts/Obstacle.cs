using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	[SerializeField] int damage = 1;
	
	public int Damage ()
	{
		return damage;
	}
}
