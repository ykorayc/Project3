using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.ScriptableObjects;
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
            if (currentTime > _maxTime)
            {
                Spawn();
            }
        }
        public void Spawn()
        {
            Instantiate(spawnerSO.enemyPrefab, spawnerSO.enemyPrefab.gameObject.transform.position, Quaternion.identity);
            currentTime = 0f;
            _maxTime = spawnerSO.randomSpawnTime;
        }
    }
}
