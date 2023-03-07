using System;
using UnityEngine;

public class EnemyHp : MonoBehaviour, Ihp
{
    #region Variables

    [SerializeField] public int StartHp;
    private int _currentHP;
    private StatisticsService _statisticsService;

    #endregion
    
    #region Events

    public event Action<int> OnHPChenge; 

    #endregion
    
    #region Unity Lifecycle

    private void Awake()
    {
        _currentHP = StartHp;
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
            _statisticsService.ChangeScore(StartHp);
            Destroy(gameObject); 
        }
        
        OnHPChenge?.Invoke(_currentHP);
    }

    #endregion
}