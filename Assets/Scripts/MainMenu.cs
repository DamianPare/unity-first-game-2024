using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject pauseMenu;


	public void PlayGame()
	{
		SceneManager.LoadScene("Play");
		Time.timeScale = 1f;
	}
	
	public void FreeRoam()
	{
		SceneManager.LoadScene("Free Roam");
		Time.timeScale = 1f;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
