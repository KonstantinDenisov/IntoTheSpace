using TMPro;
using UnityEngine;

public class UltaPersentLabel : MonoBehaviour
{
    #region Variables

    private TextMeshProUGUI _ultaPersentLabel;
    private UltaService _ultaService;

    #endregion


    #region Unity Lifecycle
    
    private void Awake()
    {
        _ultaPersentLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _ultaService = FindObjectOfType<UltaService>();
        _ultaService.OnUltaPersentChenget += UltaPersentChenget;
    }

    #endregion

    #region Private Methods

    private void UltaPersentChenget(int persent)
    {
        _ultaPersentLabel.text = $"ulta ready: {persent} %";
    }

    #endregion
}
