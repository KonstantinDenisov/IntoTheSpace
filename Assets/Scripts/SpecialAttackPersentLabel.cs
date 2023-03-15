using TMPro;
using UnityEngine;

public class SpecialAttackPersentLabel : MonoBehaviour
{
    private TextMeshProUGUI _specialAttackPersentLabel;
    [SerializeField] private SpecialAttackService _specialAttackService;

    private void Awake()
    {
        _specialAttackPersentLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _specialAttackService.OnSpecialAttackPersentChenget += SpecialAttackPersentChenget;
    }

    private void SpecialAttackPersentChenget(int persent)
    {
        _specialAttackPersentLabel.text = $"SpecialAttack ready: {persent} %";
    }
}
