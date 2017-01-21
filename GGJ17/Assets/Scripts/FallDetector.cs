using UnityEngine;
using System.Collections;

public class FallDetector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<RunBunPlayer> ().isDead = true;
			//Time.timeScale = 0;
		}
	}
}
