using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public Text scoreText;
	public Text totalscoreText;
    public Text highscoreText;
    public Text totalhighscoreText;
    public Text greenText;
    public Text blueText;
    public Text goldText;
    public Text redText;
    public static ScoreManager instance;

    public int greenDestroyed = 0;
    public int blueDestroyed = 0;
    public int goldDestroyed = 0;
    public int redDestroyed = 0;

    int score = 0;
    int highscore = 0;

    public void Start()
    {
        instance = this;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString() + " POINTS";

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }

        if (pointsToAdd == 1)
        {
            greenDestroyed++;
        }

        if (pointsToAdd == 2)
        {
            blueDestroyed++;
        }

        if (pointsToAdd == 3)
        {
            goldDestroyed++; 
        }

        if (pointsToAdd == 4)
        {
            redDestroyed++; 
        }
    }

    public void ResetPoints()
    {
        score = 0;
        scoreText.text = score.ToString() + " POINTS";
    }

    public void DisplayResults()
    {
        greenText.text = greenDestroyed.ToString() + " Green Destroyed";
        blueText.text = blueDestroyed.ToString() + " Blue Destroyed";
        goldText.text = goldDestroyed.ToString() + " Gold Destroyed";
        redText.text = redDestroyed.ToString() + " Red Destroyed";
        totalscoreText.text = score.ToString() + " POINTS";
        totalhighscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
}
