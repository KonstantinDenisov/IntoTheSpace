using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLabel : MonoBehaviour
{
    #region Variables

    private TextMeshProUGUI _scoreLabel;
    private StatisticsService _statisticsService;

    #endregion


    #region Unity Lifecycle
    
    private void Awake()
    {
        _scoreLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _statisticsService = FindObjectOfType<StatisticsService>();
        _statisticsService.OnUpDateScore += ChangeScore;
        ChangeScore();
    }

    #endregion


    #region Private Methods

    private void ChangeScore()
    {
        _scoreLabel.text = $"Score: {_statisticsService.Points}";
    }

    #endregion
}
