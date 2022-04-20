using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderFill : MonoBehaviour
{
    public Slider TimerSlider;
    public TextMeshProUGUI TimerText;
    public float GameTime;

    public bool playerSpotted;
    public float time;
    public float displayTime;

    private void Start()
    {
        playerSpotted = false;
        time = GameTime;
        TimerSlider.maxValue = GameTime;
        TimerSlider.value = GameTime;
    }

    private void Update()
    {
        if (playerSpotted && time > 0)
        {
            DecreaseTime();
        }
        else if(!playerSpotted && time <= GameTime)
        {
            IncreaseTime();
        }
        else
        {
            return;
        }
        displayTime = Mathf.Clamp(time, 0, GameTime);
        int minutes = Mathf.FloorToInt(displayTime / 60);
        int seconds = Mathf.FloorToInt(displayTime - minutes * 60f);
        string TextTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        TimerText.text = TextTime;
        TimerSlider.value = displayTime;


    }

    void DecreaseTime()
    {
       time -= Time.deltaTime;
    }

    void IncreaseTime()
    {
        time += Time.deltaTime;
    }


} 
