using System;
using System.Collections;
using UnityEngine;

public class SpawnPointEnemy : MonoBehaviour
{
   #region Variables

   [SerializeField] private float _timeEnemySpawn;
   [SerializeField] private float _timeWaveSpawn;
   
   [SerializeField] private GameObject _enemyV1;
   [SerializeField] private GameObject _enemyV2;
   [SerializeField] private GameObject _enemyV3;
   [SerializeField] private GameObject _enemyV4;
   [SerializeField] private GameObject _enemyV5;
   [SerializeField] private GameObject _enemyV6;
   [SerializeField] private GameObject _enemyV7;
   [SerializeField] private GameObject _enemyV8;

   [SerializeField] private int _enemyV1Quantity;
   [SerializeField] private int _enemyV2Quantity;
   [SerializeField] private int _enemyV3Quantity;
   [SerializeField] private int _enemyV4Quantity;
   [SerializeField] private int _enemyV5Quantity;
   [SerializeField] private int _enemyV6Quantity;
   [SerializeField] private int _enemyV7Quantity;
   [SerializeField] private int _enemyV8Quantity;

   private UiController _uiController;

   #endregion

   #region Unity Life Cycle

   private void Start()
   {
      _uiController = FindObjectOfType<UiController>();
      
      StartCoroutine(Spawn1());
   }

   #endregion


   #region Private Methods

   private IEnumerator Spawn1()
   {
      yield return new WaitForSeconds(5);
      
      for (int i = 0; i < _enemyV1Quantity; i++)
      {
         Instantiate(_enemyV1, transform.position, Quaternion.identity);
         yield return new WaitForSeconds(_timeEnemySpawn);
      }

      StartCoroutine(Spawn2());
   }

   private IEnumerator Spawn2()
   {
      yield return new WaitForSeconds(_timeWaveSpawn);
      
      for (int i = 0; i < _enemyV2Quantity; i++)
      {
         Instantiate(_enemyV2, transform.position, Quaternion.identity);
         yield return new WaitForSeconds(_timeEnemySpawn);
      }
   }

   #endregion
}
