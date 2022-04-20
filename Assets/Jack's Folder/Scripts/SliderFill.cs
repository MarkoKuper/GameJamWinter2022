using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFill : MonoBehaviour
{
    public Slider TimerSlider;
    public Text TimerText;
    public float GameTime;

    public bool playerSpotted;
    float time;

    private void Start()
    {
        playerSpotted = false;
        TimerSlider.maxValue = GameTime;
        TimerSlider.value = GameTime;
    }

    private void Update()
    {
        if (time <= 0)
        {
            return;
        }
        if (playerSpotted)
        {
            DecreaseTime();
        }
        else
        {
            IncreaseTime();
        }
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);
        string TextTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        TimerText.text = TextTime;
        TimerSlider.value = time;


    }

    void DecreaseTime()
    {
       time = GameTime - Time.time;
    }

    void IncreaseTime()
    {
        time = GameTime + Time.time;
    }


} 
