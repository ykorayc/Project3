using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Controllers;
using Project3.Abstracts.Movements;
using Project3.Movements;
using Project3.Animations;
using UnityEngine.AI;
namespace Project3.Controllers
{
    public class EnemyController : MonoBehaviour,IEntityController
    {
        [SerializeField] Transform _playerPrefab;
        IMover _mover;
        CharacterAnimations _animation;
        NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimations(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            _mover.MoveAction(_playerPrefab.transform.position,7f);
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
        }
    }

}
