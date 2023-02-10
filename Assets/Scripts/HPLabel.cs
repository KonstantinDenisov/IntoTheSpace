using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPLabel : MonoBehaviour
{
    #region Variables

    private TextMeshProUGUI _HPLabel;
    private PlayerHP _playerHp;

    #endregion


    #region Unity Lifecycle
    
    private void Awake()
    {
        _HPLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _playerHp = FindObjectOfType<PlayerHP>();
        _playerHp.OnHPChenge += ChangeScore;
    }

    #endregion

    #region Private Methods

    private void ChangeScore(int hp)
    {
        _HPLabel.text = $"Player HP: {hp}";
    }

    #endregion
}
