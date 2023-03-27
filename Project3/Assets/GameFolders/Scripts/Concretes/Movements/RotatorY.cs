using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Movements;
using Project3.Controllers;
namespace Project3.Movements
{
    public class RotatorY : IRotator
    {
        Transform _transform;
        float tilt;
        public RotatorY(PlayerController playerController)
        {
            _transform = playerController.turnTransform;
        }
        //Y icin kameranin baktigi aciyi oynatmamiz lazim.
        public void RotationAciton(float direction,float turnSpeed)
        {
            direction *= turnSpeed* Time.deltaTime;
            
            tilt = Mathf.Clamp(tilt-direction,-30f,30f);// x ekseninde - demek yukarý, + demek aþaðý çevirme. Ondan dolayý tilt-direction yaptýk.
            
            _transform.localRotation = Quaternion.Euler(tilt,0f,0f);
            
        }
    }
}


