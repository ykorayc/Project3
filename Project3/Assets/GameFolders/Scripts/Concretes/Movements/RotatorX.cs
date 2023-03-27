using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Movements;
using Project3.Controllers;
namespace Project3.Movements
{
    public class RotatorX : IRotator
    {
        PlayerController _playerController;
        //x icin karakteri oynatmamiz lazim.
        public RotatorX(PlayerController playerController)
        {
            _playerController = playerController;
        }
        public void RotationAciton(float direction,float turnSpeed)
        {
            _playerController.transform.Rotate(Vector3.up*direction*turnSpeed*Time.deltaTime); //Karakteri Y eksininde Rotate'leyecegimiz icin Vector3.Up dedik.(Saga sola donmesi icin Vector3.Up kullaniriz.)
        }
    }
}

