using System;
using UnityEngine;

public class EnemyHp : MonoBehaviour, Ihp
{
    #region Variables

    [SerializeField] public int StartHp;
    private int _currentHp;
    private StatisticsService _statisticsService;
    private SpecialAttackService _specialAttackService;

    #endregion
    
    #region Events

    public event Action<int> OnHPChenge; 

    #endregion
    
    #region Unity Lifecycle

    private void Awake()
    {
        _currentHp = StartHp;
    }

    private void Start()
    {
        _statisticsService = FindObjectOfType<StatisticsService>();
        _specialAttackService = FindObjectOfType<SpecialAttackService>();
    }
    
    #endregion


    #region Public Methods

    public void ApplyDamage(int damage)
    {
        _currentHp = _currentHp - damage;
        _specialAttackService.AddSpecialAttackPersent(damage);
        
        if (_currentHp <= 0)
        {
            _statisticsService.ChangeScore(StartHp);
            Destroy(gameObject); 
        }
        
        OnHPChenge?.Invoke(_currentHp);
    }

    #endregion
}