using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsService : MonoBehaviour
{
    public int Points;
    public event Action OnUpDateScore;
    
    private void Start()
    {
        OnUpDateScore?.Invoke();
    }

    public void ResetStatistics()
    {
        Points = 0;
    }

    public void ChangeScore(int score)
    {
        Points += score;
        OnUpDateScore?.Invoke();
    }
}
