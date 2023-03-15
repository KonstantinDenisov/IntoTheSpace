using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private HpBar _hpBar;
    [SerializeField] private EnemyHp _enemyHp;
    
    private void Start()
    {
        _enemyHp.OnHPChenge += HpChanged;
    }

    private void OnDestroy()
    {
        _enemyHp.OnHPChenge -= HpChanged;
    }
    
    private void HpChanged(int currentHp)
    {
        float fillAmount = currentHp / (float) _enemyHp.StartHp;
        _hpBar.SetFill(fillAmount);
    }
}