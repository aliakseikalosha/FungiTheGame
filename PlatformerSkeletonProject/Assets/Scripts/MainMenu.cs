using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Level 1";
    [SerializeField] private Button newGame;
    [SerializeField] private Button quit;

    private void Awake()
    {
        newGame.onClick.AddListener(StartGame);
        quit.onClick.AddListener(Application.Quit);
        if(Application.platform == RuntimePlatform.WebGLPlayer)
        {
            quit.gameObject.SetActive(false);
        }
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync(gameSceneName);
    }
}
