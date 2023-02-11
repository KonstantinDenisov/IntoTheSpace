using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    #region Variables

    [SerializeField] private HpBar _hpBar;
    [SerializeField] private EnemyHP _enemyHp;

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