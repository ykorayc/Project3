using Project3.Abstracts.Controllers;
using Project3.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Project3.States.EnemyStates
{
    public class DeadState : IState
    {
        IEnemyController _enemyController;
        float _maxTime = 5f;
        float currentTime;
        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            _enemyController.dead.DeadAction();
            _enemyController.Animation.DeadAnimation("dying");
            _enemyController.transform.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            return;

        }

        public void TickFixed()
        {
            return;
        }

        public void TickLate()
        {
            return;
        }
    }
}
