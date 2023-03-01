using System;
using Lean.Pool;
using UnityEngine;

public class PlayerAttackV1 : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPointTransform;
    [SerializeField] private float _attackDelay;
    private Transform _cachedTransform;
    private float _delayTimer;
    private AudioService _audioService;
    private UltaService _ultaService;

    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _cachedTransform = transform;
    }

    private void Start()
    {
        _audioService = FindObjectOfType<AudioService>();
        _ultaService = FindObjectOfType<UltaService>();
    }

    private void Update()
    {
        TickTimer();

        if (CanAttack())
        {
            Attack();
        }

        if (Input.GetButton("Fire2"))
        {
            Ulta();
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
        LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
        _delayTimer = _attackDelay;
        _audioService.AddTheSoundOfAGunshotClip();
    }

    private void TickTimer()
    {
        _delayTimer -= Time.deltaTime;
    }

    private void Ulta ()
    {
        Bullet bullet = _bulletPrefab.GetComponent<Bullet>();
        _ultaService.Ulta(bullet.Damage);
    }

    #endregion
}