using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Project3.Controllers
{
    public class BulletFxController : MonoBehaviour
    {
        [SerializeField] float _maxLifeTime = 5f;
        [SerializeField] float _moveSpeed = 100f;
        Rigidbody _rigidbody;
        ParticleSystem _particleSystem;
        float _currentLifetime;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();
        }
        private void Start()
        {
            _particleSystem.Play();
        }
        private void Update()
        {
            _currentLifetime += Time.deltaTime;
            if (_currentLifetime > _maxLifeTime)
            {
                Destroy(this.gameObject);

            }
        }
        private void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
        }
        public void SetDirection(Vector3 direction)
        {
            _rigidbody.velocity = direction * _moveSpeed;
        }
    }
}
