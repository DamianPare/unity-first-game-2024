using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
	[SerializeField] GameObject door;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			door.transform.position += new Vector3(0, 4, 0);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			door.transform.position -= new Vector3(0, 4, 0);
		}
	}
}
