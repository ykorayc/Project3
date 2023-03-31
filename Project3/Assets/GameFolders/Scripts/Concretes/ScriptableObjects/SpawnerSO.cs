using Project3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.ScriptableObjects
{
    [CreateAssetMenu(fileName ="SpawnerInfo",menuName ="Combat/SpawnerInfo/Create New",order =1)]
    public class SpawnerSO : ScriptableObject
    {
        [SerializeField] float minSpawnTime = 3f;
        [SerializeField] float maxSpawnTime = 15f;
        [SerializeField] EnemyController _enemPrefab;

        public EnemyController enemyPrefab => _enemPrefab;
        public float randomSpawnTime => Random.Range(minSpawnTime,maxSpawnTime);

    }

}
