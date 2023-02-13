using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    #region Variables

    [SerializeField] public int StartHp;
    private int _currentHP;
    private StatisticsService _statisticsService;
    private UltaService _ultaService;

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
        
        _ultaService = FindObjectOfType<UltaService>();
        _ultaService.AllEnemys.Add(this);
    }

    private void OnDestroy()
    {
        _ultaService.AllEnemys.Remove(this);
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
        _ultaService.AddUltaPersent(5);

    }

    #endregion
}