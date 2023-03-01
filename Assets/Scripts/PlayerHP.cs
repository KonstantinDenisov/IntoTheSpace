using System;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _startHp;
    private int _currentHP;
    private GameOverScreenService _gameOverScreenService;

    #endregion


    #region Events

    public event Action<int> OnHPChenge; 

    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _currentHP = _startHp;
    }

    private void Start()
    {
        _gameOverScreenService = FindObjectOfType<GameOverScreenService>();
        OnHPChenge?.Invoke(_currentHP);
    }

    #endregion


    #region Public Methods

    public void ApplyDamage(int damage)
    {
        _currentHP = _currentHP - damage;
        if (_currentHP <= 0)
        {
            _gameOverScreenService.GameOver();
            Destroy(gameObject);
        }
        OnHPChenge?.Invoke(_currentHP);
    }

    #endregion
}