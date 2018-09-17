using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
	//component holders
	GameMaster gm;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		gm = FindObjectOfType<GameMaster>(); //populate with gm script
		rb = GetComponent<Rigidbody2D>(); //populate with Rigidbody component
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2( -gm.Speed(), 0 ); //applies current game speed to object
	}
}