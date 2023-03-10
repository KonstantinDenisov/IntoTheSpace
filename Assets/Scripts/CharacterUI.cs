using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    #region Variables

    [SerializeField] private HpBar _hpBar;
    [SerializeField] private EnemyHp _enemyHp;

    #endregion


    #region Unity Life Cycle

    private void Start()
    {
        _enemyHp.OnHPChenge += HpChanged;
    }

    private void OnDestroy()
    {
        _enemyHp.OnHPChenge -= HpChanged;
    }

    #endregion


    #region Private Methods

    private void HpChanged(int currentHp)
    {
        float fillAmount = currentHp / (float) _enemyHp.StartHp;
        _hpBar.SetFill(fillAmount);
    }

    #endregion
}