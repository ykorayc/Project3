using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Helpers;
using Project3.Controllers;

namespace Project3.Managers
{
    public class EnemyManager : SingletonMonobehavior<EnemyManager>
    {
        [SerializeField] int _maxEnemyCount=50;
        [SerializeField] List<EnemyController> _enemies;
        public bool canSpawn=> _maxEnemyCount>_enemies.Count;
        private void Awake()
        {
            SetSingletonThisObject(this);
            _enemies = new List<EnemyController>();
        }
        public void SetEnemyController(EnemyController enemyController)
        {
            enemyController.transform.SetParent(EnemyManager.instance.transform);
            EnemyManager.instance._enemies.Add(enemyController);
        }
        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
        }
    }

}
