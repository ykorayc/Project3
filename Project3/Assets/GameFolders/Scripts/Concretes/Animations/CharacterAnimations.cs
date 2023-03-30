using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Controllers;
using Project3.Abstracts.Controllers;
namespace Project3.Animations
{
    public class CharacterAnimations : MonoBehaviour
    {
        Animator _animator;
        public CharacterAnimations(IEntityController entity)
        {
            _animator = entity.transform.GetComponentInChildren<Animator>();
        }
        public void MoveAnimation(float moveSpeed)
        {
            if(_animator.GetFloat("MoveSpeed") == moveSpeed) return;
            _animator.SetFloat("MoveSpeed",moveSpeed,.1f,Time.deltaTime); //damper yavas bir sekilde value'muzun artmasýný saglar.
        }
        public void AttackAnimation(bool isattackButtonPressed)
        {
            _animator.SetBool("isAttack",isattackButtonPressed);
        }
    }

}
