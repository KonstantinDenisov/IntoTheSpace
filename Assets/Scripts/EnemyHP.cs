using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _startHp;

    public event Action<int> OnChanged;
    public int CurrentHp { get; private set; }

    #endregion
    
    #region Unity Lifecycle

    private void Awake()
    {
        CurrentHp = _startHp;
        OnChanged?.Invoke(CurrentHp);
    }

    #endregion


    #region Public Methods

    public void ApplyDamage(int damage)
    {
        CurrentHp = Mathf.Max(0, CurrentHp - damage);
        OnChanged?.Invoke(CurrentHp);
    }

    public void ApplyHeal(int heal)
    {
        CurrentHp = CurrentHp + heal;
        OnChanged?.Invoke(CurrentHp);
    }

    #endregion
}