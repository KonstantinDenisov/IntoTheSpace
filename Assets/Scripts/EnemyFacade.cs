using UnityEngine;

public class EnemyFacade : MonoBehaviour
{
  [SerializeField] private EnemyHp _enemyHp;
  [SerializeField] private MoveDown _moveDown;
  [SerializeField] private SinusoidMotion _sinusoidMotion;
  [SerializeField] private EnemyAttack _enemyAttack;
  [SerializeField] private CharacterUI _characterUI;
  
  private SpecialAttackService _specialAttackService;

  private void Start()
  {
    _specialAttackService = FindObjectOfType<SpecialAttackService>();
    _specialAttackService.AllEnemys.Add(this);
  }
  
  private void OnDestroy()
  {
    _specialAttackService.AllEnemys.Remove(this);
  }

  public void ApplyDamage(int damage)
  {
    _enemyHp.ApplyDamage(damage);
    _specialAttackService.AddSpecialAttackPersent(5);
  }
}
