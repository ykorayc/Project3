using Project3.Abstracts.Controllers;
using Project3.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Project3.States.EnemyStates
{
    public class ChaseState : IState
    {
        float _speed = 10f;
        IEnemyController _enemyController;
        public ChaseState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
        }

        public void OnExit()
        {
            _enemyController.Mover.MoveAction(_enemyController.transform.position,0f);
        }

        public void Tick()
        {
            _enemyController.Mover.MoveAction(_enemyController.Target.position,_speed);
        }

        public void TickFixed()
        {
        }

        public void TickLate()
        {
            _enemyController.Animation.MoveAnimation(_enemyController.Magnitude);
        }
    }

}
