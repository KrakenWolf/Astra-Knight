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

    public GameManager gameManager;
    private Button backToMain;
    private Button exitButton;
    private Button retry;
    private GameObject Trigger;

    private GameObject mainPlayer1;
    private GameObject bossPlayer;
    private GameObject cutscenePlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("level 1"))
        {
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.CompareTag("level 2"))
        {
            SceneManager.LoadScene(3);
        }
        if (other.gameObject.CompareTag("level 4"))
        {
            SceneManager.LoadScene(4);
        }
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(2);
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
