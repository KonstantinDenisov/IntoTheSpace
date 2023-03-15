using TMPro;
using UnityEngine;

public class PlayerHpLabel : MonoBehaviour
{
    private TextMeshProUGUI _hpLabel;
    private PlayerHp _playerHp;
    
    private void Awake()
    {
        _hpLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _playerHp = FindObjectOfType<PlayerHp>();
        _playerHp.OnHPChenge += ChangeScore;
    }
    
    private void ChangeScore(int hp)
    {
        _hpLabel.text = $"Player HP: {hp}";
    }
}
