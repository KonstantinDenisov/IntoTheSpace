using System;
using UnityEngine;

public class EnemyHp : MonoBehaviour, Ihp
{
    [SerializeField] public int StartHp;
    private int _currentHp;
    private StatisticsService _statisticsService;
    private SpecialAttackService _specialAttackService;

    public event Action<int> OnHPChenge;

    private void Awake()
    {
        _currentHp = StartHp;
    }

    private void Start()
    {
        _statisticsService = FindObjectOfType<StatisticsService>();
        _specialAttackService = FindObjectOfType<SpecialAttackService>();
    }
    
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
}