using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour 
{
	public GameObject[] platformPrefabs;
	public Transform spawnLocation;
	public float maxTime = 2f;
	public float minTime = 0.5f;
	public float spawnTime = 3f;
	private float time;

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("spawnPlatform", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		time += Time.deltaTime;

		if (time >= spawnTime) 
		{
			spawnPlatform ();
		}

	}

	void spawnPlatform()
	{
		time = 0f;
		GameObject platform = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], spawnLocation.position, Quaternion.Euler(0,0,0)) as GameObject;
	}

	//void SetRandomTime()
	//{
	//	spawnTime = Random.Range(minTime, maxTime);
	//}

}
