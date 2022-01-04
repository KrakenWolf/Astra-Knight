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
    private Button startButton;
    private Button exitButton;
    private Button backToMain;
    private GameObject Trigger;

    private GameObject mainPlayer1;
    private GameObject bossPlayer;
    private GameObject cutscenePlayer;

    private void Awake()
    {
        Button button = startButton.GetComponent<Button>();
        Button button1 = exitButton.GetComponent<Button>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
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
        }
        if (other.gameObject.CompareTag("level 4"))
        {
            SceneManager.LoadScene(4);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
