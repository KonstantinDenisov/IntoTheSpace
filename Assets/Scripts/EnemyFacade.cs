using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacade : MonoBehaviour
{
  [SerializeField] private EnemyHp _enemyHp;
  [SerializeField] private MoveDown _moveDown;
  [SerializeField] private SinusoidMotion _sinusoidMotion;
  [SerializeField] private EnemyAttack _enemyAttack;
  [SerializeField] private CharacterUI _characterUI;
  
  public void ApplyDamage(int damage)
  {
    _enemyHp.ApplyDamage(damage);
  }
}
