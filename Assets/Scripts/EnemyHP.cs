using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _startHp;
    private int _currentHP;
    private StatisticsService _statisticsService;

    #endregion
    
    #region Unity Lifecycle

    private void Awake()
    {
        _currentHP = _startHp;
    }

    private void Start()
    {
        _statisticsService = FindObjectOfType<StatisticsService>();
    }

    #endregion


    #region Public Methods

    public void ApplyDamage(int damage)
    {
        _currentHP = _currentHP - damage;
        if (_currentHP <= 0)
        {
            _statisticsService.ChangeScore(_startHp);
            Destroy(gameObject); 
        }
    }

    #endregion
}