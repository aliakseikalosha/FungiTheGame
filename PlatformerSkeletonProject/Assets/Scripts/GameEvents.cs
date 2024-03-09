using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameEvents
{
    public static event Action OnDeath;
    public static event Action<int> OnScoreGain;
    public static event Action<int> OnHealthChange;
    public static event Action<int> OnGetHurt;

    public static void PlayerDie()
    {
        OnDeath?.Invoke();
    }

    public static void AddScore(int score)
    {
        OnScoreGain?.Invoke(score);
    }

    public static void UpdateHealth(int health)
    {
        OnHealthChange?.Invoke(health);
    }
}
