using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINav : MonoBehaviour
{
	[SerializeField] private Transform MoveTo;
	[SerializeField] private NavMeshAgent Agent;

	void Update()
	{
		Agent.destination = MoveTo.position;
	}
}
