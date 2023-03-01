using System;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class UltaService : MonoBehaviour
{
  #region Variables

  public List<EnemyHP> AllEnemys;
  public int UltaPersent;
  [SerializeField] private GameObject _prefub;
  [SerializeField] private Transform _spawnPoint;
  
  #endregion


  #region Enents

  public event Action<int> OnUltaPersentChenget;

  #endregion


  #region Public Methods

  public void AddUltaPersent(int persent)
  {
    UltaPersent += persent;
    OnUltaPersentChenget?.Invoke(UltaPersent);
  }

  public void Ulta (int damage)
  {
    if (UltaPersent < 100)
    {
      return;
    }

    LeanPool.Spawn(_prefub, _spawnPoint.position, Quaternion.identity);

    UltaPersent -= 100;
    OnUltaPersentChenget?.Invoke(UltaPersent);
    
    int ultaDamege = damage * 3;
    
    foreach (var enemyHp in AllEnemys)
    {
      enemyHp.ApplyDamage(ultaDamege);
    }
  }

  #endregion
}
