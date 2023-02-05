using System.Collections;
using Lean.Pool;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;
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
        if (col.CompareTag(Tags.Player))
        {
            PlayerHP playerHp = col.gameObject.GetComponentInParent<PlayerHP>();
            
            if (playerHp != null)
            { 
                playerHp.ApplyDamage(_damage);
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