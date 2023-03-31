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
            _enemyController.transform.LookAt(_enemyController.Target);
            //Animasyon yere yatiyordu dondugumuzde. Bunu duzeltmek icin rotation'ini hep y'sinden cevirmemiz laz�m.
            //x ve z'sini rotate edersek karakter asagi saga sola egilir.
            //Degisim sadece y ekseninde olur, x ekseninde olmaz.
            _enemyController.transform.eulerAngles=new Vector3(0f,_enemyController.transform.eulerAngles.y,0f);
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
