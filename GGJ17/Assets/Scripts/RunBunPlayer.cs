using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RunBunPlayer : MonoBehaviour 
{
	public float jumpSpeed = 100.0f;
	public float width = 5.0f;
	public bool isDead = false;
	public bool hasWon = false;
	public bool hasFallen = false;
	public GameObject gameManager;
	Animator anim;
	public Text text;
	public AudioSource[] sounds;
	public AudioSource noise1;
	public AudioSource noise2;
	public AudioSource noise3;
	public AudioSource[] playerSounds;
	public AudioSource sound1;
	public AudioSource sound2;
	public AudioSource sound3;
	public AudioSource sound4;
	bool soundplayed;

	public AudioClip slideClip;

	Transform playerFoot;

	private Rigidbody2D rb2d;
	BoxCollider2D playerCollider;

	public float jumpX;
	public float jumpY;
	public float runX;
	public float runY;
	public float slideX;
	public float slideY;

	private float time;

	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		playerCollider = gameObject.GetComponent<BoxCollider2D>();
		playerFoot = transform.FindChild("PlayerFoot").transform;
		gameManager = GameObject.Find("PointsManager");
		anim = GetComponent<Animator>();
		playerSounds = GetComponents<AudioSource> ();
		sound1 = playerSounds [0];
		sound2 = playerSounds [1];
		sound3 = playerSounds [2];
		sound4 = playerSounds [3];
		soundplayed = false;
		sound3.mute = true;

//		sounds = GetComponents<AudioSource>();
//		noise1 = sounds[0];
//		noise2 = sounds[1];
//		noise3 = sounds[2];
	}

	void Update() 
	{
		if (isDead == false && hasWon == false)
		{
			sound3.Stop ();
			text.text = time.ToString("F1") + " meters";
			anim.SetInteger ("Direction", 0);
			playerCollider.size = new Vector2(runX, runY);
		}
		if (IsGrounded())
		{
			if(!soundplayed)
			{
				sound2.Play ();
				soundplayed = true;
			}
			if (isDead == false && hasWon == false && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				sound4.Play ();
				sound3.Stop ();
				sound2.Stop ();
				PlayerJump();  
				soundplayed = false;
			}
			if (isDead == false && hasWon == false && Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) 
			{
				sound2.Pause ();
				anim.SetInteger ("Direction", 2);
				playerCollider.size = new Vector2 (slideX, slideY);
			}
			if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S))
			{
				sound3.mute = false;
			}
			if (Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.S)) 
			{
				sound3.mute = true;
			}
		}
		else
		{
			anim.SetInteger ("Direction", 1);
			playerCollider.size = new Vector2(jumpX, jumpY);
		}
		if (isDead == true) 
		{
			sound2.Stop ();
			//Debug.Log ("You're dead!");
		}
	}

	void FixedUpdate()
	{
		time += Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			sound2.Stop ();
			noise1.Play();
			Debug.Log("You died...");
			noise3.Stop();
//			DieMe();  
//			rb2d.isKinematic = true;
			anim.enabled = false;
		}
		if (collision.gameObject.tag == "Goal")
		{
			noise2.Play();
			Debug.Log("You win!");
			hasWon = true;
		}
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.tag == "Detector")
		{
			hasFallen = true;
			Debug.Log("You hit the pit detector!");
		}
	}


//	void DieMe()
//	{
//		if (!isDead)
//		{
//			if (gameManager.GetComponent<RetryCounter>() )
//				gameManager.GetComponent<RetryCounter>().IncrementDeathCounter() ;
//		}
//		isDead = true;
//
//	}

	void PlayerJump()
	{
		rb2d.AddForce(Vector2.up * jumpSpeed);
	}

	bool IsGrounded()
	{
		RaycastHit2D[] hits = Physics2D.RaycastAll(playerFoot.position, Vector2.right, width);

		Debug.DrawLine(playerFoot.position,
			playerFoot.position + Vector3.right * width,
			Color.red);

		for (int i = 0; i < hits.Length; ++i)
		{
			if (hits[i].transform.tag == "Ground")
			{
				return true;
			}
		}
		return false;
	}

}