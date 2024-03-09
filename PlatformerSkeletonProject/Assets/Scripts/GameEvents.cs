using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action OnDeath;
    public static event Action<int> OnScoreGain;

    public static void PlayerDie()
    {
        OnDeath?.Invoke();
    }

    public static void AddScore(int score)
    {
        OnScoreGain?.Invoke(score);
    }
}
