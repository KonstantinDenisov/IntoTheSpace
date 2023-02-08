using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    #region Variables
    
    [Header("Screens")]
    [SerializeField] private GameObject _gameWinScreen;
    [SerializeField] private GameObject _gameOverLabel;
    [SerializeField] private GameObject _pauseImage;
    
    [Header("Buttons")]
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _resumeToGameButton;
    [SerializeField] private Button _exitButtonGameOver;
    [SerializeField] private Button _exitButtonPause;
    [SerializeField] private Button _exitGameWinScreen;
    [SerializeField] private Button _restartGameButtonGameOver;

    private PauseService _pauseService;
    private StatisticsService _statisticsService;
    
    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _gameWinScreen.SetActive(false);
        _gameOverLabel.SetActive(false);
        _pauseImage.SetActive(false);
        
        _restartGameButtonGameOver.onClick.AddListener(RestartGameButtonCliced);
        _playAgainButton.onClick.AddListener(RestartGameButtonCliced);
        _resumeToGameButton.onClick.AddListener(ResumeToGameButtonCliced);
        _exitButtonGameOver.onClick.AddListener(ExitButtonCliced);
        _exitButtonPause.onClick.AddListener(ExitButtonCliced);
        _exitGameWinScreen.onClick.AddListener(ExitButtonCliced);
    }

    private void Start()
    {
        _pauseService = FindObjectOfType<PauseService>();
        _pauseService.OnPaused += Paused;

        _statisticsService = FindObjectOfType<StatisticsService>();
        _statisticsService.OnGameOver += GameOver;
        _statisticsService.OnGameWinn += GameWin;
    }

    private void OnDestroy()
    {
        _pauseService.OnPaused -= Paused;
        _statisticsService.OnGameOver -= GameOver;
        _statisticsService.OnGameWinn -= GameWin;
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

    private void RestartGameButtonCliced()
    {
        _pauseService.PauseSwitcher();
        _statisticsService.ResetStatistics();
    }

    private void ResumeToGameButtonCliced()
    {
        _pauseService.PauseSwitcher();
    }

    private void Paused(bool isPaused)
    {
        _pauseImage.SetActive(isPaused);
    }

    private void GameWin()
    {
        _gameWinScreen.SetActive(true);  
        _pauseService.PauseSwitcher();
        //AudioPlayer.AddWinAudioClip();
    }


    private void GameOver()
    { 
        _gameOverLabel.SetActive(true);
        _pauseService.PauseSwitcher();
        //AudioPlayer.AddGameOverAudioClip();
    }

    #endregion
}
