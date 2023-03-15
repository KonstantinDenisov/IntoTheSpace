using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLabel : MonoBehaviour
{
    private TextMeshProUGUI _scoreLabel;
    [SerializeField] private StatisticsService _statisticsService;
    
    private void Awake()
    {
        _scoreLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _statisticsService.OnUpDateScore += ChangeScore;
        ChangeScore();
    }

    private void ChangeScore()
    {
        _scoreLabel.text = $"Score: {_statisticsService.Points}";
    }
}
