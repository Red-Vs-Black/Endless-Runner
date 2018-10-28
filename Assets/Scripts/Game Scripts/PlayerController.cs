using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//TODO Remove serialization after testing.
	[SerializeField] private bool inAir = false;	//toggle for when player is mid-jump
	[SerializeField] private bool sliding = false;	//toggle for while player is mid-slide
	private float slideTimer = 0f;	//timer that counts the length of the current slide
	
	//Assignable attributes
	[Tooltip("Minimum volume for player sounds")] [SerializeField] float volLowRange = 0.5f;
	[Tooltip("Maximum volume for player sounds")] [SerializeField] float volHighRange = 1.0f;
	[Tooltip("Lowest pitch of player sounds")] [SerializeField] float lowPitchRange = 0.75f;
	[Tooltip("Highest pitch of player sounds")] [SerializeField] float highPitchRange = 1.5f;
	[Tooltip ("Sound player makes when jumpping")] [SerializeField] AudioClip jumpSound;
	[Tooltip ("Sound player makes while sliding")] [SerializeField] AudioClip slideSound;
	[Tooltip ("Sound player makes upon landing")] [SerializeField] AudioClip landingSound;
	
	//component holders
	GameMaster gm;	//TODO remove if unused
	Player thePlayer;	//holder for Player stats script
	Rigidbody2D rb;	//holder for Rigidbody component
	AudioSource aSource;	//holder for audio component

	// Use this for initialization
	void Start ()
	{
		gm = FindObjectOfType<GameMaster> (); //populate with gm script
		thePlayer = GetComponent<Player> (); //populate with player script
		rb = GetComponent<Rigidbody2D> (); //populate with Rigidbody component
		aSource = GetComponent<AudioSource> (); //populat with AudioSource component
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (sliding)
		{
			slideTimer += Time.deltaTime;
			
			if (slideTimer >= thePlayer.GetSlide ())
			{
				sliding = false;
				slideTimer = 0f;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Obstacle"))
		{
			thePlayer.ModHealth(-other.GetComponent<Obstacle> ().Damage ());
			//thePlayer.ModHealth(-1);
		}
	}

	public void Jump ()
	{
		if (!inAir)
		{
			float vol = Random.Range (volLowRange, volHighRange);
			aSource.pitch = Random.Range (lowPitchRange, highPitchRange);
			aSource.PlayOneShot (jumpSound, vol);
			
			rb.AddForce( new Vector2( 0, thePlayer.GetJump() ) ); //applies jump force in upward direction
			inAir = true; //mark player as midair
		}
		else
		{
			//do nothing
		}
	}
	
	public void Slide ()
	{
		if (!sliding)
		{
			float vol = Random.Range (volLowRange, volHighRange);
			aSource.pitch = Random.Range (lowPitchRange, highPitchRange);
			aSource.PlayOneShot (slideSound, vol);
			
			Debug.Log ("We're sliding!");
			sliding = true;
			//TODO slide animation
		}
		else
		{
			//do nothing
		}
	}
	
	public void LandAlready () //public function that allows ground checker to remove mid-air flag
	{
		float vol = Random.Range (volLowRange, volHighRange);
		aSource.pitch = Random.Range (lowPitchRange, highPitchRange);
		aSource.PlayOneShot (landingSound, vol);

		inAir = false;
	}
	
}
