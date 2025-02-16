using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeHUD : MonoBehaviour
{
	public GameObject Range;
	[SerializeField] TimerRange Timer;
	[SerializeField] TargetManager Targets;
	private bool inFreeRoam => Range == null || Targets == null;

	void Start()
	{
		if(inFreeRoam)
		{
			return;
		}
		Range.SetActive(false);
		
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(inFreeRoam)
		{
			return;
		}

		if (other.CompareTag("Player"))
		{
			Range.SetActive(true);
			Timer.ResetTimer();
			Targets.ResetPoints();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Range.SetActive(false);
		}
	}
}
