using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[Serializable]public class TimerScript : GameManager
{
    public GameObject timerCanvas;
    private Button startButton;

    public bool level1;

    //Timer
    public static float currentTime;
    public float bestTime;
    public Text timerText;
    public Text bestText;

    private void Awake()
    {
        timerCanvas = this.gameObject;

        if (this.timerCanvas)
        {
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        if (currentTime < bestTime)
        {
            bestText.text = PlayerPrefs.GetFloat("Best Time").ToString();
        }
        if (currentTime > bestTime)
        {
            bestText = timerText;
        }
    }

    private void LateUpdate()
    {
        TimingIt();
    }

    void TimingIt()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            
            timerText.text = time.ToString(@"mm\:ss\:ff");
        }
    }

    public void Best()
    {
        bestText.text = currentTime.ToString();

        if(currentTime > PlayerPrefs.GetFloat("Best Time"))
        {
            PlayerPrefs.SetFloat("Best Time", currentTime);
            bestText.text = currentTime.ToString();
        }
    }



    public void RestetScore()
    {
        PlayerPrefs.DeleteAll();
        TimerScript.bestText.text = "0";
    }

    public void SaveTime()
    {
        PlayerPrefs.SetFloat("Best Time", currentTime);
    }
}
