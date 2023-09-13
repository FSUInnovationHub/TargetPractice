using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Assets.Scripts.Events;
using System;

public class TimerManager : MonoBehaviour
{

    public float timeRemaining; //in seconds.

    private bool isTimeRemaining = true;
    private bool isTimerPaused = true;

    public TextMeshPro timeText;
    public TextMeshPro anounncerText;

    public GameEvent onTimeRunOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeTimerPause()
    {
        isTimerPaused = !isTimerPaused;

        if(isTimerPaused == true)
        {
            anounncerText.text = "Best Time";
            TimerCountdown(PlayerPrefs.GetInt("bestTime"));
        }
        else
        {
            anounncerText.text = "Time Left";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerPaused == false)
        {
            ShowTime();
        }
    }



    private void ShowTime()
    {
        if (isTimeRemaining)
        {
            timeRemaining -= Time.deltaTime; // The Update() function is called every frame. But we don't the timer to work in frames it needs to work in seconds.
                                             // Time.deltaTime measures the time between each frame. It essentially lets us measure how much time has passed in seconds.
                                             // There are other ways to set up a timer which may seem more intuitive to create but are not as efficient such as Coroutines.
            TimerCountdown(timeRemaining);
        }
        else
        {
            onTimeRunOut.Raise();

            timeText.text = "0:00";
        }

    }

    private void TimerCountdown(float timeLeft)
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60); // The percent sign here is called a modulo. When you use it it gives you the remander of a division operation.
                                                              // For example: Let's pretend we had to calculate what 62 seconds was.
                                                              // 
                                                              // Imagine doing 62/60 by hand. You would first do 62 - 60 = 2. Since you can't subtract 60 anymore that 2 is the remainder.
                                                              //TODO make a better explanation for this.

        if(seconds > 10)
        {
            timeText.text = minutes + ":" + seconds;
        }
        else
        {
            timeText.text = minutes + ":0" + seconds; 
        }

        if (timeLeft == 0)
        {
            isTimeRemaining = false;
        }
        
    }

    public void CheckHighScore() //Called when all targets are knocked down.
    {
        int bestTime = PlayerPrefs.GetInt("bestTime");
        if (bestTime > timeRemaining)
        {
            PlayerPrefs.SetInt("bestTime", (int)timeRemaining);
            TimerCountdown(timeRemaining);
            anounncerText.text = "Best Time";
        }
    }


}
