using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnPointEnemy : MonoBehaviour
{
   [SerializeField] private float _timeEnemySpawn;
   [SerializeField] private float _timeWaveSpawn;

   [SerializeField] private List <GameObject> _enemys;

   [SerializeField] private List <int> _enemyQuantity;

   [SerializeField] private GameWinScreen _gameWinScreen;

   private void Start()
   {
      StartCoroutine(Spawn());
   }
   
   private IEnumerator Spawn()
   {
      for (int i = 0; i < _enemys.Count; i++)
      {
         yield return new WaitForSeconds(_timeWaveSpawn);
         
         for (int j = 0; j < _enemyQuantity[i]; j++)
         {
            yield return new WaitForSeconds(_timeEnemySpawn);

            Instantiate(_enemys[i], transform.position, quaternion.identity);
         }
      }
   }
}
