using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button continueGame;
    [SerializeField] private Button restart;
    [SerializeField] private Button quit;

    private void Awake()
    {
        panel.SetActive(false);
        continueGame.onClick.AddListener(Continue);
        restart.onClick.AddListener(RestartLevel);
        quit.onClick.AddListener(Application.Quit);
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            quit.gameObject.SetActive(false);
        }
        GameEvents.OnDeath += LoadResult;
    }

    private void LoadResult()
    {
        GameEvents.OnDeath -= LoadResult;
        SceneManager.LoadSceneAsync("ResultScreen");
    }

    private void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            if (panel.activeInHierarchy)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause(bool isPaused = true)
    {
        panel.SetActive(isPaused);
        Time.timeScale = isPaused? 0 : 1;
    }

    private void Continue()
    {
        Pause(false);
    }
}
