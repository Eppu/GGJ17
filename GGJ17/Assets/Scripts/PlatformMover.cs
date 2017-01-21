using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour 
{
	public float moveSpeed = 5.0f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdatePlatformPosition();
	}

	void UpdatePlatformPosition()
	{
		transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
	}

}
