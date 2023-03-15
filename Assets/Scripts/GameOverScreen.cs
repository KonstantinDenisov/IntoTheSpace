using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverLabel;

    [Header("Buttons")]
    [SerializeField] private Button _exitButtonGameOver;
    [SerializeField] private Button _restartGameButtonGameOver;
    [SerializeField] private GameUi _gameUi;

    private PauseService _pauseService;
    private StatisticsService _statisticsService;
    private AudioService _audioService;
    
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

    public void GameOver()
    {
        _gameOverLabel.SetActive(true);
        _pauseService.PauseSwitcher();
        _gameUi.HudSwitcher();
        //AudioPlayer.AddGameOverAudioClip();
    }
    
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
}
