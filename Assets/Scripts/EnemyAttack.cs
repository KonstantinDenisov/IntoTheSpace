using Lean.Pool;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPointTransform;
    [SerializeField] private float _attackDelay;
    private Transform _cachedTransform;
    private float _delayTimer;
    private AudioService _audioService;

    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _cachedTransform = transform;
    }
    
    private void Start()
    {
        _audioService = FindObjectOfType<AudioService>();
    }

    private void Update()
    {
        TickTimer();

        if (CanAttack())
        {
            Attack();
        }
    }

    #endregion


    #region Private Methods

    private bool CanAttack()
    {
        return _delayTimer <= 0;
    }

    private void Attack()
    {
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
        _delayTimer = _attackDelay;
        _audioService.AddTheSoundOfAGunshotClip();
    }

    private void TickTimer()
    {
        _delayTimer -= Time.deltaTime;
    }

    #endregion
}
