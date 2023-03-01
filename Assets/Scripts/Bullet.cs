using System.Collections;
using Lean.Pool;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] public int Damage;
    [SerializeField] private bool _isEnemyBullet;
    private Rigidbody2D _rb;

    #endregion


    #region Unity Lifecycle

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
        if (_isEnemyBullet)
        {
            if (col.CompareTag(Tags.Player))
            {
                PlayerHp playerHp = col.gameObject.GetComponentInParent<PlayerHp>();
            
                if (playerHp != null)
                { 
                    playerHp.ApplyDamage(Damage);
                }
            }
        }

        else
        {
            if (col.CompareTag(Tags.Enemy))
            {
                EnemyHp enemyHp = col.gameObject.GetComponentInParent<EnemyHp>();
            
                if (enemyHp != null)
                { 
                    enemyHp.ApplyDamage(Damage);
                }
            }
        }
    }

    #endregion


    #region Private Methods

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

    #endregion
}