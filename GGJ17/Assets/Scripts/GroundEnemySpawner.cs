using UnityEngine;
using System.Collections;

public class GroundEnemySpawner : MonoBehaviour 
{

	public GameObject GroundEnemy;
	public Transform spawnLocation;
	public float maxTime = 5f;
	public float minTime = 2f;

	private float spawnTime;
	private float time;

	void Start ()
	{
		InvokeRepeating ("spawnGroundEnemy", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		time += Time.deltaTime;

		if (time >= spawnTime) 
		{
			spawnGroundEnemy ();
			SetRandomTime ();
		}

	}

	void spawnGroundEnemy()
	{
		time = minTime;
		GameObject platform = Instantiate(GroundEnemy, spawnLocation.position, Quaternion.Euler(0,0,0)) as GameObject;
	}

	void SetRandomTime()
	{
		spawnTime = Random.Range(minTime, maxTime);
	}

}