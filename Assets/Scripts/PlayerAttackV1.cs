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
    private SpecialAttackService _specialAttackService;

    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _cachedTransform = transform;
    }

    private void Start()
    {
        _specialAttackService = FindObjectOfType<SpecialAttackService>();
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
        AudioService.Instance.AddTheSoundOfAGunshotClip();
    }

    private void TickTimer()
    {
        _delayTimer -= Time.deltaTime;
    }

    private void Ulta ()
    {
        Bullet bullet = _bulletPrefab.GetComponent<Bullet>();
        _specialAttackService.SpecialAttack(bullet.Damage);
    }

    #endregion
}