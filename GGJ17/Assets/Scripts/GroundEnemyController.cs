using UnityEngine;
using System.Collections;

public class GroundEnemyController : MonoBehaviour 
{
	public float moveSpeed = 5.0f;

	void Start () 
	{
		Time.timeScale = 1;
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
			other.gameObject.GetComponent<RunBunPlayer> ().isDead = true;
		}
	}
}
