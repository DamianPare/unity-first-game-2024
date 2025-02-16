using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRange : MonoBehaviour
{
    public Text timerText;
    public float startTime;
    private float timer;

    void Start()
    {
        timer = startTime;
    }

    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = (int)(timer / 60);
        int seconds = (int)(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        timer = 0f;
    }
}
