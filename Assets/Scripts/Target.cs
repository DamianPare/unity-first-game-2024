using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject); // when target is hit, destroys target
		TargetManager.instance.AddPoint();
	}
}
