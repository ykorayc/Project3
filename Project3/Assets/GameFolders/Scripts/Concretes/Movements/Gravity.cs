using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Movements
{
    public class Gravity : MonoBehaviour
    {
        [SerializeField] float gravity = -9.81f;
        CharacterController _characterController;
        Vector3 velocity;
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_characterController.isGrounded) velocity.y = 0;

            velocity.y += gravity * Time.deltaTime;
            _characterController.Move(velocity*Time.deltaTime);
        }

    }

}
