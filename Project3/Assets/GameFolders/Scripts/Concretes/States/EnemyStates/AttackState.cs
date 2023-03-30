using Project3.Abstracts.Controllers;
using Project3.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Project3.States.EnemyStates
{
    public class AttackState : IState
    {
        IEnemyController _enemyController;

        public AttackState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
        }

        public void OnExit()
        {
            _enemyController.Animation.AttackAnimation(false);
        }

        public void Tick()
        {
        }

        public void TickFixed()
        {
            _enemyController.Inventory.currentWeapon.Atack();
        }
        public void TickLate()
        {
            _enemyController.Animation.AttackAnimation(true);
        }
    }

}
