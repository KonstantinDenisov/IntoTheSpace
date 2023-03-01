using TMPro;
using UnityEngine;

public class PlayerHpLabel : MonoBehaviour
{
    #region Variables

    private TextMeshProUGUI _hpLabel;
    private PlayerHP _playerHp;

    #endregion


    #region Unity Lifecycle
    
    private void Awake()
    {
        _hpLabel = GetComponent<TextMeshProUGUI>();
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
        _hpLabel.text = $"Player HP: {hp}";
    }

    #endregion
}
