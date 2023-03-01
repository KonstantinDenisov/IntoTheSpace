using System;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    #region Variables

    [SerializeField] public int StartHp;
    private int _currentHP;
    private StatisticsService _statisticsService;
    private SpecialAttackService _specialAttackService;

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
        
        _specialAttackService = FindObjectOfType<SpecialAttackService>();
        _specialAttackService.AllEnemys.Add(this);
    }

    private void OnDestroy()
    {
        _specialAttackService.AllEnemys.Remove(this);
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
        _specialAttackService.AddSpecialAttackPersent(5);

    }

    #endregion
}