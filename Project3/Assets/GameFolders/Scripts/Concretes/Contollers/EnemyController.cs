using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Controllers;
using Project3.Abstracts.Movements;
using Project3.Movements;
using Project3.Animations;
using UnityEngine.AI;
using Project3.Abstracts.Combats;
using Project3.Controllers;
namespace Project3.Controllers
{
    public class EnemyController : MonoBehaviour,IEntityController
    {
        IMover _mover;
        IHealth _health;
        CharacterAnimations _animation;
        NavMeshAgent _navMeshAgent;
        InventoryController _inventoryController;

        
        Transform _playerTransform;
        bool _canAttack;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimations(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health= GetComponent<IHealth>();
            _inventoryController = GetComponent<InventoryController>();
        }
        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform; 
        }
        private void Update()
        {
            if (_health.isDead) return;
            _mover.MoveAction(_playerTransform.position,7f);

            _canAttack = Vector3.Distance(_playerTransform.position, this.transform.position) <=_navMeshAgent.stoppingDistance && _navMeshAgent.velocity==Vector3.zero;
        }
        private void FixedUpdate()
        {
            if (_canAttack)
            {
                _inventoryController.currentWeapon.Atack();
            }
            
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _animation.AttackAnimation(_canAttack);
        }
    }

}
