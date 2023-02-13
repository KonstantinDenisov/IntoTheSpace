using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltaService : MonoBehaviour
{
  #region Variables

  public List<EnemyHP> AllEnemys;
  public int UltaPersent;
  public event Action OnUltaPersentChenget;
  

  #endregion

  #region Public Methods

  public void AddUltaPersent(int persent)
  {
    UltaPersent += persent;
    OnUltaPersentChenget?.Invoke();
  }

  public void Ulta (int damage)
  {
    if (UltaPersent < 100)
    {
      return;
    }

    UltaPersent -= 100;
    OnUltaPersentChenget?.Invoke();
    
    int ultaDamege = damage * 3;
    
    foreach (var enemyHp in AllEnemys)
    {
      enemyHp.ApplyDamage(ultaDamege);
    }
  }

  #endregion
}
