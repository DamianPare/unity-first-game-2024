using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Orb"))
		{
			Debug.Log("Spawned inside");
			Destroy(other.gameObject);
		}
	}
}
