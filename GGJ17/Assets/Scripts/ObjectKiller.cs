using UnityEngine;
using System.Collections;

public class ObjectKiller : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			Destroy (col.gameObject);
		}
	}
}
