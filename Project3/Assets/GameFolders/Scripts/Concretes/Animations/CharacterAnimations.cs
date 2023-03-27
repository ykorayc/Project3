using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Controllers;
namespace Project3.Animations
{
    public class CharacterAnimations : MonoBehaviour
    {
        Animator _animator;
        public CharacterAnimations(PlayerController _playerController)
        {
            _animator = _playerController.GetComponentInChildren<Animator>();
        }
        public void MoveAnimation(float moveSpeed)
        {
            _animator.SetFloat("MoveSpeed",moveSpeed,.1f,Time.deltaTime); //damper yavas bir sekilde value'muzun artmasýný saglar.
        }
    }

}
