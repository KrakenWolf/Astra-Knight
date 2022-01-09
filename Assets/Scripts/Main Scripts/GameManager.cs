using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public TimerScript TimerScript;
    public static bool stopwatchActive;

    public GameManager gameManager;
    private GameObject Trigger;

    private GameObject mainPlayer1;
    private GameObject bossPlayer;
    private GameObject cutscenePlayer;

    private void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("level 1"))
        {
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.CompareTag("level 2"))
        {
            SceneManager.LoadScene(3);
            //PlayerPrefs.SetFloat("Best Time", currentTime);
            //Debug.Log("Saved");
        }
        if (other.gameObject.CompareTag("level 4"))
        {
            SceneManager.LoadScene(4);
        }
    }

    public void BackToMenu()
    {
       SceneManager.LoadScene(0);
       stopwatchActive = false;
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void StartGame()
    {
        stopwatchActive = true;
        SceneManager.LoadScene(1);
        TimerScript.timerCanvas.SetActive(true);
    }

    public void Exit()
    {

        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        }
    }

}
