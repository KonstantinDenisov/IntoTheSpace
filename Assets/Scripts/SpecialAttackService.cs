using System;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class SpecialAttackService : MonoBehaviour
{
  public List<EnemyFacade> AllEnemys;
  public int SpecialAttackPersent;
  [SerializeField] private GameObject _prefub;
  [SerializeField] private Transform _spawnPoint;

  public event Action<int> OnSpecialAttackPersentChenget;

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
    
    foreach (var enemyFacade in AllEnemys)
    {
      enemyFacade.ApplyDamage(SpecialAttackDamege);
    }
  }
}
