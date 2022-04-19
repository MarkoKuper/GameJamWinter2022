using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFill : MonoBehaviour
{
    public Slider TimerSlider;
    public Text TimerText;
    public float GameTime;

    private bool StopTimer;

    private void Start()
    {
        StopTimer = false;
        TimerSlider.maxValue = GameTime;
        TimerSlider.value = GameTime;
    }

    private void Update()
    {
        float time = GameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);
        string TextTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (time <= 0)
        {
            StopTimer = true;
        }
        if(StopTimer == false)
        {
            TimerText.text = TextTime;
            TimerSlider.value = time;
        }
    }


} 
