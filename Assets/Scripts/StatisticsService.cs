using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsService : MonoBehaviour
{
    #region Variables
    
    public int Points;

    #endregion
    
    #region Events

    public event Action OnGameOver;
    public event Action OnGameWinn;

    #endregion
    
    #region Public Methods

    public void ResetStatistics()
    {
        Points = 0;
    }

    public void ChangeScore(int score)
    {
        Points += score;
    }

    #endregion
    
    
}
