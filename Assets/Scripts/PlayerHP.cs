using System;
using UnityEngine;

[Serializable]
public class PlayerHp : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _startHp;
    private int _currentHp;
    private GameOverScreenService _gameOverScreenService;

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
        _gameOverScreenService = FindObjectOfType<GameOverScreenService>();
        OnHPChenge?.Invoke(_currentHp);
    }

    #endregion


    #region Public Methods

    public void ApplyDamage(int damage)
    {
        _currentHp = _currentHp - damage;
        if (_currentHp <= 0)
        {
            _gameOverScreenService.GameOver();
            Destroy(gameObject);
        }
        OnHPChenge?.Invoke(_currentHp);
    }

    #endregion
}