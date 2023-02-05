using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _startHp;
    private int _currentHP;

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
            Destroy(gameObject);
    }
    

    #endregion
}