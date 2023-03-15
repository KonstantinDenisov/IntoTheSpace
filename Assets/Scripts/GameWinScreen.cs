using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameWinScreen;

    [Header("Buttons")]
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _exitGameWinScreen;

    [SerializeField] private PauseService _pauseService;
    [SerializeField] private StatisticsService _statisticsService;

    private void Awake()
    {
        _gameWinScreen.SetActive(false);
        _playAgainButton.onClick.AddListener(RestartGameButtonCliced);
        _exitGameWinScreen.onClick.AddListener(ExitButtonCliced);
    }
    
    public void GameWin()
    {
        _gameWinScreen.SetActive(true);  
        _pauseService.PauseSwitcher();
        //AudioPlayer.AddWinAudioClip();
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
