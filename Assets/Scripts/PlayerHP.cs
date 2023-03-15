using System;
using UnityEngine;

[Serializable]
public class PlayerHp : MonoBehaviour, Ihp
{
    [SerializeField] private int _startHp;
    private int _currentHp;
    private GameOverScreen _gameOverScreen;

    public event Action<int> OnHPChenge;
    
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
}