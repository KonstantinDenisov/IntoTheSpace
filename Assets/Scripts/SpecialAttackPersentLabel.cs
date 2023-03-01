using TMPro;
using UnityEngine;

public class SpecialAttackPersentLabel : MonoBehaviour
{
    #region Variables

    private TextMeshProUGUI _specialAttackPersentLabel;
    private SpecialAttackService _specialAttackService;

    #endregion


    #region Unity Lifecycle
    
    private void Awake()
    {
        _specialAttackPersentLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _specialAttackService = FindObjectOfType<SpecialAttackService>();
        _specialAttackService.OnSpecialAttackPersentChenget += SpecialAttackPersentChenget;
    }

    #endregion

    #region Private Methods

    private void SpecialAttackPersentChenget(int persent)
    {
        _specialAttackPersentLabel.text = $"SpecialAttack ready: {persent} %";
    }

    #endregion
}
