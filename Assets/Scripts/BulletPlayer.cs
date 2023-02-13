using System.Collections;
using Lean.Pool;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletPlayer : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] public int Damage;
    private Rigidbody2D _rb;

    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _speed;
        StartCoroutine(LifeTimeTimer());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Tags.Enemy))
        {
            EnemyHP enemyHp = col.gameObject.GetComponentInParent<EnemyHP>();
            
            if (enemyHp != null)
            { 
                enemyHp.ApplyDamage(Damage);
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