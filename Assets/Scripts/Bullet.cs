using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float life = 3; // bullet lifespan in seconds

	void Awake()
	{
		Destroy(gameObject, life); //destroys bullet after lifespan ends
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject); // destroys bullet when it hits something
	}

}
   