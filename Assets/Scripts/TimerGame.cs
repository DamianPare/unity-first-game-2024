using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject player;
    public Vector3 target;
    public GameObject Game;
    public GameObject ResultsMenu;

    void Start()
    {
        timerBar = GetComponent<Image> ();
        timeLeft = maxTime;
        ResultsMenu.SetActive(false);
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            Game.SetActive(false);
            ResultsMenu.SetActive(true);
		    Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ScoreManager.instance.DisplayResults();
            //player.transform.position = target;
            //timeLeft = maxTime;
        }
    }

}
