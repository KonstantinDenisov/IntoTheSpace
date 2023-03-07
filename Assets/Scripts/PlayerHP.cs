using System;
using UnityEngine;

[Serializable]
public class PlayerHp : MonoBehaviour, Ihp
{
    #region Variables

    [SerializeField] private int _startHp;
    private int _currentHp;
    private GameOverScreen _gameOverScreen;

    #endregion


    #region Events

    public event Action<int> OnHPChenge; 

    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _currentHp = _startHp;
    }

    private void Start()
    {
        _startHp = 100;
        _gameOverScreen = FindObjectOfType<GameOverScreen>();
        OnHPChenge?.Invoke(_currentHp);
    }

    #endregion


    #region Public Methods

    public void ApplyDamage(int damage)
    {
        _currentHp = _currentHp - damage;
        if (_currentHp <= 0)
        {
            _gameOverScreen.GameOver();
            Destroy(gameObject);
        }
        OnHPChenge?.Invoke(_currentHp);
    }

    #endregion
}