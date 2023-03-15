﻿using System.Collections;
using Lean.Pool;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] public int Damage;
    [SerializeField] private bool _isEnemyBullet;
    private Rigidbody2D _rb;

    private void Awake()
    {
        StartCoroutine(LifeTimeTimer());
        _rb = GetComponent<Rigidbody2D>();
        if (_isEnemyBullet)
        {
            _rb.velocity = transform.up * _speed * -1;
        }
        else
        {
            _rb.velocity = transform.up * _speed; 
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        string target;
        
        if (_isEnemyBullet)
        {
            target = Tags.Player;
        }
        
        else
        {
            target = Tags.Enemy;
        }
        
        if (col.gameObject.CompareTag(target))
        {
            Ihp ihp = col.gameObject.GetComponentInParent<Ihp>();
            
                if (ihp != null)
                { 
                    ihp.ApplyDamage(Damage);
                }
        }
    }

    private IEnumerator LifeTimeTimer()
    {
        yield return new WaitForSeconds(_lifeTime);
       Destroy(gameObject);
       //Despawn();
    }

    private void Despawn()
    {
        LeanPool.Despawn(gameObject);
    }
}