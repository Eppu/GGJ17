using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour
{
	public float targetScale = 1f;
	public float shrinkSpeed = 10.0f;
	//public bool shrinking;
	public GameObject splat;

	void Update()
	{
		if(GameObject.Find("Player").GetComponent<RunBunPlayer>().isDead == true)
		{
			splat.transform.localScale = Vector3.Lerp(splat.transform.localScale,
				new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);

			if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Return) ||Input.GetKeyDown(KeyCode.Space))
			{
				Application.LoadLevel(0);
			}
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}


}