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
	public AudioSource[] sounds;
	public AudioSource noise1;
	public AudioSource noise2;
	public AudioSource noise3;

	Transform playerFoot;

	private Rigidbody2D rb2d;
	BoxCollider2D playerCollider;

	public float jumpX;
	public float jumpY;
	public float runX;
	public float runY;
	public float slideX;
	public float slideY;

	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		playerCollider = gameObject.GetComponent<BoxCollider2D>();
		playerFoot = transform.FindChild("PlayerFoot").transform;
		gameManager = GameObject.Find("PointsManager");
		anim = GetComponent<Animator>();
//		sounds = GetComponents<AudioSource>();
//		noise1 = sounds[0];
//		noise2 = sounds[1];
//		noise3 = sounds[2];
	}

	void Update() 
	{
		if (isDead == false && hasWon == false)
		{
			anim.SetInteger ("Direction", 0);
			playerCollider.size = new Vector2(runX, runY);
		}
		if (IsGrounded())
		{
			if (isDead == false && hasWon == false && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				PlayerJump();   
			}
			if (isDead == false && hasWon == false && Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) 
			{
				anim.SetInteger ("Direction", 2);
				playerCollider.size = new Vector2 (slideX, slideY);
			}
		}
		else
		{
			anim.SetInteger ("Direction", 1);
			playerCollider.size = new Vector2(jumpX, jumpY);
		}
		if (isDead == true) 
		{
			//Debug.Log ("You're dead!");
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
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