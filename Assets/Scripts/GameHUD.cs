using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
	public GameObject GameUI;
	[SerializeField] ScoreManager Points;
	
	void Start()
	{
		GameUI.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameUI.SetActive(true);
			Points.ResetPoints();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameUI.SetActive(false);
		}
	}

}
