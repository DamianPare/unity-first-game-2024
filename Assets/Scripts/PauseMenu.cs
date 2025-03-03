using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenu;
	public bool IsPaused;
	public GameObject ResultsMenu;

	void Start()
	{
		pauseMenu.SetActive(false);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && ResultsMenu.activeSelf == false)
		{
			if(IsPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}

	public void PauseGame()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		IsPaused = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		IsPaused = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void QuitGame()
	{
		SceneManager.LoadScene("Main Menu");
	}
}