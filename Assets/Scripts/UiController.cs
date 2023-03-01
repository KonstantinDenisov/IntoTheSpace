using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    #region Variables
    
    [Header("Screens")]
    [SerializeField] private GameObject _startImage;
    [SerializeField] private GameObject _hud;

    [Header("Buttons")]
    [SerializeField] private Button _spaceshipV1;
    [SerializeField] private Button _spaceshipV2;

    [SerializeField] private GameObject _spawnPointPlayer;
    [SerializeField] private GameObject _spaceShipV1Prefab;
    [SerializeField] private GameObject _spaceShipV2Prefab;

    private PauseService _pauseService;
    private StatisticsService _statisticsService;
    private AudioService _audioService;
    
    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _hud.SetActive(false);
        _startImage.SetActive(true);
        
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

    #endregion
    
    #region Public Methods

    public void GameOver()
    { 
        _hud.SetActive(false);
        _pauseService.PauseSwitcher();
        //AudioPlayer.AddGameOverAudioClip();
    }

    #endregion

    #region Private Methods

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
        _hud.SetActive(true);
        _pauseService.PauseSwitcher();
    }

    #endregion
}
