using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    [SerializeField] private Data[] mushroom;
    [SerializeField] private string gameSceneName = "Level 1";
    [SerializeField] private Button oneMore;
    [SerializeField] private Button quit;

    private void Awake()
    {
        oneMore.onClick.AddListener(StartGame);
        quit.onClick.AddListener(Application.Quit);
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            quit.gameObject.SetActive(false);
        }

        score.text = $"{Score.ScoreCount} pt";
        foreach (var item in mushroom)
        {
            item.Compare(Score.ScoreCount);
        }
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync(gameSceneName);
    }

    [Serializable]
    public class Data
    {
        [SerializeField] private GameObject mushroom;
        [SerializeField] private int targetScore;

        public void Compare(int collected)
        {
            mushroom.SetActive(collected > targetScore);
        }
    }
}
