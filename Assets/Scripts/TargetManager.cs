using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    public Text destroyedText;
    public float destroyed = 0;
    public static TargetManager instance;

    void Start()
    {
        instance = this;
        destroyedText.text = destroyed.ToString() + " Targets Destroyed";
    }

    public void AddPoint()
    {
        destroyed += 1;
        destroyedText.text = destroyed.ToString() + " Targets Destroyed";
    }

    public void ResetPoints()
    {
        destroyed = 0f;
        destroyedText.text = destroyed.ToString() + " Targets Destroyed";
    }
}