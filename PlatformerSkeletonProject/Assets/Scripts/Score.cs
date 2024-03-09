using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public static int ScoreCount;

    private void Awake()
    {
        ScoreCount = 0;
        AddScore(0);
        GameEvents.OnScoreGain += AddScore;
        GameEvents.OnDeath += PlayerDeath;
    }

    private void PlayerDeath()
    {
        GameEvents.OnScoreGain -= AddScore;
        GameEvents.OnDeath -= PlayerDeath;
    }

    private void AddScore(int score)
    {
        ScoreCount += score;
        Text.text = "Score: " + ScoreCount;
    }
}
