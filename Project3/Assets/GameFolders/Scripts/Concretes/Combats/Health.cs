using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Combats;
using Project3.ScriptableObjects;
namespace Project3.Combats
{
    public class Health : MonoBehaviour, IHealth
    {

        int _currentHealth;
        [SerializeField] HealthSO _healthInfo;
        public bool isDead => _currentHealth <= 0;

        public event System.Action<int, int> OnTakeHit;
        private void Awake()
        {
            _currentHealth = _healthInfo._maxHealth;
        }
        public void TakeDamage(int damage)
        {
            if (isDead) return;
            _currentHealth -= damage;
            OnTakeHit?.Invoke(_currentHealth,_healthInfo._maxHealth);
        }
    }

}