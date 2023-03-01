using System;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class SpecialAttackService : MonoBehaviour
{
  #region Variables

  public List<EnemyHp> AllEnemys;
  public int SpecialAttackPersent;
  [SerializeField] private GameObject _prefub;
  [SerializeField] private Transform _spawnPoint;
  
  #endregion


  #region Enents

  public event Action<int> OnSpecialAttackPersentChenget;

  #endregion


  #region Public Methods

  public void AddSpecialAttackPersent(int persent)
  {
    SpecialAttackPersent += persent;
    OnSpecialAttackPersentChenget?.Invoke(SpecialAttackPersent);
  }

  public void SpecialAttack (int damage)
  {
    if (SpecialAttackPersent < 100)
    {
      return;
    }

    LeanPool.Spawn(_prefub, _spawnPoint.position, Quaternion.identity);

    SpecialAttackPersent -= 100;
    OnSpecialAttackPersentChenget?.Invoke(SpecialAttackPersent);
    
    int SpecialAttackDamege = damage * 3;
    
    foreach (var enemyHp in AllEnemys)
    {
      enemyHp.ApplyDamage(SpecialAttackDamege);
    }
  }

  #endregion
}
