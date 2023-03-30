using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Inputs;
using Project3.Abstracts.Movements;
using Project3.Animations;
using Project3.Movements;
using Project3.Controllers;
using Project3.Abstracts.Controllers;
namespace Project3.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movement Information")]
        [SerializeField] float moveSpeed;
        [SerializeField] float turnSpeed;

        [SerializeField] Transform _turnTransform;


        public Transform turnTransform => _turnTransform;  //Baska scriptlerde kullanabilmek icin Property'sini olusturmak zorundayiz.

        IInputReader _InputReader;
        IMover _mover;

        Vector3 direction;
        Vector2 rotation;

        IRotator xRotation;
        IRotator yRotation;


        CharacterAnimations _animations;

        InventoryController _inventory;

        private void Awake()
        {
            _InputReader = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this,moveSpeed);
            _animations = new CharacterAnimations(this);
            xRotation = new RotatorX(this);
            yRotation = new RotatorY(this);
            _inventory = GetComponent<InventoryController>();
        }
        private void Update()
        {
            direction = _InputReader.direction;
            rotation = _InputReader.rotation;
            xRotation.RotationAciton(rotation.x, turnSpeed);
            yRotation.RotationAciton(rotation.y, turnSpeed);

            if (_InputReader.isAttackButtonPress)
            {
                //_currentWeapon.Atack();
                _inventory.currentWeapon.Atack();
            }
            if (_InputReader.isInventoryButtonPressed)
            {
                _inventory.ChangeWeapon();
            }

        }
        private void FixedUpdate()
        {
            _mover.MoveAction(direction,moveSpeed);  //Burdan alýrsak her turlu oyun calisirken degiskeni degistirdigimizde RunTime'dan sonucu gorebiliriz.
            
        }
        private void LateUpdate()
        {
            //Animasyon Ýslemlerimizi LateUpdate'te yapariz.
            _animations.MoveAnimation(direction.magnitude);
        }

    }
}
