using Lean.Pool;
using UnityEngine;

public class PlayerAttackV2 : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPointTransformCentr;
    [SerializeField] private Transform _bulletSpawnPointTransformRight;
    [SerializeField] private Transform _bulletSpawnPointTransformLeft;
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
        return Input.GetButton("Fire1") && _delayTimer <= 0;
    }

    private void Attack()
    {
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransformCentr.position, _bulletSpawnPointTransformCentr.rotation);
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransformRight.position, _bulletSpawnPointTransformRight.rotation);
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransformLeft.position, _bulletSpawnPointTransformLeft.rotation);
        _delayTimer = _attackDelay;
        _audioService.AddTheSoundOfAGunshotClip();
    }

    private void TickTimer()
    {
        _delayTimer -= Time.deltaTime;
    }

    #endregion
}
