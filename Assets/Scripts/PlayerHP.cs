using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _startHp;
    private int _currentHP;

    #endregion


    #region Events

    public event Action<int> OnHPChenge; 

    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _currentHP = _startHp;
    }

    #endregion


    #region Public Methods

    public void ApplyDamage(int damage)
    {
        _currentHP = _currentHP - damage;
        if (_currentHP <= 0)
        {
            Destroy(gameObject);
        }
        OnHPChenge?.Invoke(_currentHP);
    }

    #endregion
}