using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointEnemy : MonoBehaviour
{
   #region Variables

   [SerializeField] private float _timeEnemySpawn;
   [SerializeField] private float _timeWaveSpawn;

   [SerializeField] private List <GameObject> _enemys;

   [SerializeField] private List <int> _enemyQuantity;

   private GameWinScreenService _gameWinScreenService;

   #endregion

   #region Unity Life Cycle

   private void Start()
   {
      _gameWinScreenService = FindObjectOfType<GameWinScreenService>();
      
      StartCoroutine(FirstSpawn());
   }

   #endregion


   #region Private Methods

   private IEnumerator FirstSpawn()
   {
      yield return new WaitForSeconds(5);
      
      for (int i = 0; i < _enemyQuantity[0]; i++)
      {
         Instantiate(_enemys[0], transform.position, Quaternion.identity);
         yield return new WaitForSeconds(_timeEnemySpawn);
      }

      int numberOfWaves = _enemys.Count;

      for (int i = 1; i < numberOfWaves; i++)
      {
         yield return new WaitForSeconds(_timeWaveSpawn);

         StartCoroutine(NextSpawn(i));
      }
   }

   private IEnumerator NextSpawn(int currentWaveNumber)
   {
      for (int i = 0; i < _enemyQuantity[currentWaveNumber]; i++)
      {
         Instantiate(_enemys[i], transform.position, Quaternion.identity);
         yield return new WaitForSeconds(_timeEnemySpawn);
      }
   }

   #endregion
}
