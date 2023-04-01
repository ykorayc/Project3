using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.ScriptableObjects;
using Project3.Managers;

namespace Project3.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] SpawnerSO spawnerSO;
        [SerializeField] float _maxTime;
        float currentTime = 0;
        private void Start()
        {
            _maxTime = spawnerSO.randomSpawnTime;
        }
        private void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime > _maxTime && EnemyManager.instance.canSpawn && !GameManager.instance.isWaveFinished)
            {
                Spawn();
            }
        }
        public void Spawn()
        {
            EnemyController enemyController=Instantiate(spawnerSO.enemyPrefab, this.transform.position, Quaternion.identity);
            //EnemyManager icerisinde olusturdugumuz list'in icerisine, olusturdugumuz enemy prefablerini atiyoruz.
            EnemyManager.instance.SetEnemyController(enemyController);
            currentTime = 0f;
            _maxTime = spawnerSO.randomSpawnTime;
        }
    }
}
