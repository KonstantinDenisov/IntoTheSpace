using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    #region Variables
    
    [Header("Screens")]
    [SerializeField] private GameObject _gameOverLabel;
    [SerializeField] private GameObject _startImage;
    [SerializeField] private GameObject _HUD;

    [Header("Buttons")]
    [SerializeField] private Button _exitButtonGameOver;
    [SerializeField] private Button _restartGameButtonGameOver;
    [SerializeField] private Button _spaceshipV1;
    [SerializeField] private Button _spaceshipV2;

    [SerializeField] private GameObject _spawnPointPlayer;
    [SerializeField] private GameObject _spaceShipV1Prefab;
    [SerializeField] private GameObject _spaceShipV2Prefab;

    [SerializeField] private SceneLoadingService _sceneLoadingService;

    private PauseService _pauseService;
    private StatisticsService _statisticsService;
    private AudioService _audioService;
    
    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _gameOverLabel.SetActive(false);
        _HUD.SetActive(false);
        _startImage.SetActive(true);

        _restartGameButtonGameOver.onClick.AddListener(RestartGameButtonCliced);
        _exitButtonGameOver.onClick.AddListener(ExitButtonCliced);
        _spaceshipV1.onClick.AddListener(CreateSpaceShipV1);
        _spaceshipV2.onClick.AddListener(CreateSpaceShipV2);
    }

    private void Start()
    {
        _pauseService = FindObjectOfType<PauseService>();
        _statisticsService = FindObjectOfType<StatisticsService>();
        _audioService = FindObjectOfType<AudioService>();

        _pauseService.PauseSwitcher();
    }

    private void OnDestroy()
    {
        _statisticsService.OnGameOver -= GameOver;
    }

    #endregion
    
    #region Public Methods

    public void GameOver()
    { 
        _HUD.SetActive(false);
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
        _sceneLoadingService.ReloadScene();
    }

    private void CreateSpaceShipV1()
    {
        Instantiate(_spaceShipV1Prefab, _spawnPointPlayer.transform.position, Quaternion.identity);
        StartGame();
    }

    private void CreateSpaceShipV2()
    {
        Instantiate(_spaceShipV2Prefab, _spawnPointPlayer.transform.position, Quaternion.identity);
        StartGame();
    }

    private void StartGame()
    {
        _startImage.SetActive(false);
        _HUD.SetActive(true);
        _pauseService.PauseSwitcher();
    }

    #endregion
}
