using UnityEngine;
using UnityEngine.UI;

public class PauseScreenService : MonoBehaviour
{
#region Variables

    [SerializeField] private GameObject _pauseImage;

    [Header("Buttons")]
    [SerializeField] private Button _resumeToGameButton;
    [SerializeField] private Button _exitButtonPause;
    [SerializeField] private Button _audioServiceON;
    [SerializeField] private Button _audioServiceOFF;

    private PauseService _pauseService;
    private AudioService _audioService;
    
    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _pauseImage.SetActive(false);
        _resumeToGameButton.onClick.AddListener(ResumeToGameButtonCliced);
        _exitButtonPause.onClick.AddListener(ExitButtonCliced);
        _audioServiceON.onClick.AddListener(AudioServiceOn);
        _audioServiceOFF.onClick.AddListener(AudioServiceOff);
    }

    private void Start()
    {
        _pauseService = FindObjectOfType<PauseService>();
        _pauseService.OnPaused += Paused;
        _audioService = FindObjectOfType<AudioService>();
    }

    private void OnDestroy()
    {
        _pauseService.OnPaused -= Paused;
    }

    #endregion
    
    
    #region Private Methods

    private void ExitButtonCliced()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void ResumeToGameButtonCliced()
    {
        _pauseService.PauseSwitcher();
    }

    private void Paused(bool isPaused)
    {
        _pauseImage.SetActive(isPaused);
    }

    private void AudioServiceOn()
    {
        _audioService.SoundOff = false;
    }
    
    private void AudioServiceOff()
    {
        _audioService.SoundOff = true;
    }

    #endregion
}
