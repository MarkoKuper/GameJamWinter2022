using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    public bool keepTiming;
    float timer;


    void Start()
    {
        keepTiming = false;
    }

    void Update()
    {

        if (keepTiming)
        {
            UpdateTime();
        }
    }

    public void UpdateTime()
    {
        timer = Time.time - startTime;
        timerText.text = TimeToString(timer);
    }

    public float StopTimer()
    {
        keepTiming = false;
        return timer;
    }

    public void ResumeTimer()
    {
        keepTiming = true;
        startTime = Time.time - timer;
    }

    public void StartTimer()
    {
        keepTiming = true;
        startTime = Time.time;
    }

    string TimeToString(float t) 
    {
        string minutes = ((int)t / 60).ToString("0");
        string seconds = (t % 60).ToString("00");
        return minutes + ":" + seconds;
    }
}

