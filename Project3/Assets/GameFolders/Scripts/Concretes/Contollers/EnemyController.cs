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
using Project3.States;
using Project3.States.EnemyStates;
using Project3.Abstracts.States;
using Project3.Combats;
using Project3.Managers;

namespace Project3.Controllers
{
    public class EnemyController : MonoBehaviour,IEnemyController
    {
        IHealth _health;
        NavMeshAgent _navMeshAgent;
        public Transform Target { get; set; }

        bool _canAttack;
        public bool CanAttack=> Vector3.Distance(Target.position, this.transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;

        public IMover Mover { get; private set; }

        public InventoryController Inventory { get; private set; }

        public CharacterAnimations Animation { get; private set; }


       

        StateMachine _stateMachine;

        public float Magnitude => _navMeshAgent.velocity.magnitude;

        public Dead dead { get; private set; }

        private void Awake()
        {
            Mover = new MoveWithNavMesh(this);
            Animation = new CharacterAnimations(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health= GetComponent<IHealth>();
            Inventory = GetComponent<InventoryController>();
            _stateMachine = new StateMachine();
            dead = GetComponent<Dead>();
        }
        private void Start()
        {
            Target = FindObjectOfType<PlayerController>().transform;
            ChaseState chaseState = new ChaseState(this);
            AttackState attackState = new AttackState(this);
            DeadState deadState = new DeadState(this);

            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.isDead);

            _stateMachine.SetState(chaseState);
        }
        private void Update()
        {
            
            _stateMachine.Tick();

        }
        private void FixedUpdate()
        {
            _stateMachine.TickFixed();
            
        }
        private void LateUpdate()
        {
            _stateMachine.TickLate();
        }
        private void OnDestroy()
        {
            EnemyManager.instance.RemoveEnemyController(this);
        }
    }

}
