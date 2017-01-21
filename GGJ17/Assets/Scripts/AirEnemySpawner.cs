using UnityEngine;
using System.Collections;

public class AirEnemySpawner : MonoBehaviour 
{

	public GameObject[] AirEnemyPrefabs;
	public Transform spawnLocation;
	public float maxTime = 5f;
	public float minTime = 2f;

	private float spawnTime;
	private float time;

	void Start ()
	{
		InvokeRepeating ("spawnAirEnemy", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		time += Time.deltaTime;

		if (time >= spawnTime) 
		{
			spawnAirEnemy ();
			SetRandomTime ();
		}

	}

	void spawnAirEnemy()
	{
		time = minTime;
		GameObject platform = Instantiate(AirEnemyPrefabs[Random.Range(0, AirEnemyPrefabs.Length)], spawnLocation.position, Quaternion.Euler(0,0,0)) as GameObject;
	}

	void SetRandomTime()
	{
		spawnTime = Random.Range(minTime, maxTime);
	}

}