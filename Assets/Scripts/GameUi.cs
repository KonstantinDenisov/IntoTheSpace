using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject _startImage;
    [SerializeField] private GameObject _hud;

    [Header("Buttons")]
    [SerializeField] private Button _spaceshipV1;
    [SerializeField] private Button _spaceshipV2;

    [Header("Service")]
    [SerializeField] private PauseService _pauseService;
    [SerializeField] private StatisticsService _statisticsService;
    private AudioService _audioService;

    [SerializeField] private GameObject _spawnPointPlayer;
    [SerializeField] private GameObject _spaceShipV1Prefab;
    [SerializeField] private GameObject _spaceShipV2Prefab;

    private bool _isHudActive;
    
    private void Awake()
    {
        _hud.SetActive(false);
        _startImage.SetActive(true);
        
        _spaceshipV1.onClick.AddListener(CreateSpaceShipV1);
        _spaceshipV2.onClick.AddListener(CreateSpaceShipV2);
    }

    private void Start()
    {
        _audioService = FindObjectOfType<AudioService>();

        _pauseService.PauseSwitcher();
    }
    
    public void HudSwitcher()
    {
        _isHudActive = !_isHudActive;
        _hud.SetActive(_isHudActive);
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
        _hud.SetActive(true);
        _pauseService.PauseSwitcher();
    }
}
