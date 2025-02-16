using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsMenu : MonoBehaviour
{
	public GameObject resultsMenu;

	void Start()
	{
		resultsMenu.SetActive(false);
	}


	public void Retry()
	{
		SceneManager.LoadScene("Play");
	}
	
	public void MainMenu()
	{
		SceneManager.LoadScene("Main Menu");
	}
}
