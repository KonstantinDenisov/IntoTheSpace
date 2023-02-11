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
        throw new NotImplementedException();
    }

    #endregion


    //   _health.OnChanged += HpChanged;
         //   HpChanged(_health.CurrentHp);
    
         

    private void OnDestroy()
    {
       // if (_health != null)
          //  _health.OnChanged -= HpChanged;
    }

    private void HpChanged(int currentHp)
    {
      //  float fillAmount = currentHp / (float) _health.MaxHp;
       // _hpBar.SetFill(fillAmount);
    }
}
