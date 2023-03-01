using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenService : MonoBehaviour
{
   #region Variables
   
    [SerializeField] private GameObject _gameOverLabel;

    [Header("Buttons")]
    [SerializeField] private Button _exitButtonGameOver;
    [SerializeField] private Button _restartGameButtonGameOver;

    [SerializeField] private GameObject _hud;

    private PauseService _pauseService;
    private StatisticsService _statisticsService;
    private AudioService _audioService;
    
    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _gameOverLabel.SetActive(false);

        _restartGameButtonGameOver.onClick.AddListener(RestartGameButtonCliced);
        _exitButtonGameOver.onClick.AddListener(ExitButtonCliced);
    }

    private void Start()
    {
        _pauseService = FindObjectOfType<PauseService>();
        _statisticsService = FindObjectOfType<StatisticsService>();
        _audioService = FindObjectOfType<AudioService>();
    }

    #endregion
    
    #region Public Methods

    public void GameOver()
    { 
        _hud.SetActive(false);
        _gameOverLabel.SetActive(true);
        _pauseService.PauseSwitcher();
        //AudioPlayer.AddGameOverAudioClip();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion
}
