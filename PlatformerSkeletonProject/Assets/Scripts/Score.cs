using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public int ScoreCount;

    private void Awake()
    {
        GameEvents.OnScoreGain += AddScore;
    }

    private void AddScore(int score)
    {
        ScoreCount += score;
        Text.text = "Score: " + ScoreCount;
    }
}
