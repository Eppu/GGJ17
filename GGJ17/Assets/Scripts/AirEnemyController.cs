using UnityEngine;
using System.Collections;

public class AirEnemyController : MonoBehaviour 
{
	public float moveSpeed = 5.0f;
	public AudioSource squishSound;
	public AudioClip playerDieSound;

	void Start () 
	{
		//Time.timeScale = 1;
		squishSound = GetComponent<AudioSource>();
	}

	void Update ()
	{
		UpdateEnemyPosition();
	}

	void UpdateEnemyPosition()
	{
		transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			squishSound.Play ();
			other.gameObject.GetComponent<RunBunPlayer> ().isDead = true;
			//Time.timeScale = 0;
			squishSound.PlayOneShot(playerDieSound);
		}
	}
}
