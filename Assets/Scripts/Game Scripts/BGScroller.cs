using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	//NOTE Texture must be set to Wrap Mode: Repeat for script to function.
	Material texture; //Holder for Texture reference.
	GameMaster gm;
	
	[Tooltip("Reduces background speed by this multiplier")] [SerializeField] float padding = 2f;
	
	void Start ()
	{
		gm = FindObjectOfType <GameMaster> ();
		texture = GetComponent <Renderer> ().material;
	}
	
	void Update ()
	{
		Vector2 offset = new Vector2 (Time.time * gm.Speed () / padding, 0);
		
		texture.SetTextureOffset ("_MainTex", offset);
	}
	
}
