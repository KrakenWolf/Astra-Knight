using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TimerScript : GameManager
{
    public GameObject timer;
    private Button startButton;

    public bool level1;

    //Timer
    bool stopwatchActive = false;
    float currentTime;
    //public Text currentText;

    //Score
    int Score;
    public Text scoreText;
    public float multiplier;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (gameObject == null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentTime = 0;
    }

    private void Update()
    {
        TimingIt();
    }

    void TimingIt()
    {
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }

        Score = Mathf.RoundToInt(currentTime * multiplier);
        scoreText.text = Score.ToString();
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        //currentText.text = time.ToString(@"mm\:ss\:ff");
    }

    public void StartGame()
    {
        stopwatchActive = true;
        SceneManager.LoadScene(1);
        timer.SetActive(true);

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Best Score", Score);
    }
}
