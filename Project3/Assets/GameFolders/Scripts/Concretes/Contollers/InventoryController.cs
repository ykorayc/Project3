using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Controllers
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] WeaponController[] _weapons;
        public WeaponController currentWeapon { get; private set; }
        Animator _animator;
        byte _index = 0;

        private void Awake()
        {
            _weapons = GetComponentsInChildren<WeaponController>();
            foreach (WeaponController weapon in _weapons)
            {
                weapon.gameObject.SetActive(false);
            }
            _animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            currentWeapon = _weapons[_index];
            currentWeapon.gameObject.SetActive(true);
        }
        public void ChangeWeapon()
        {
            _index++;
            if (_index >= _weapons.Length)
            {
                _index = 0;
            }
            currentWeapon = _weapons[_index];
            foreach (WeaponController weapon in _weapons)
            {
                if (currentWeapon == weapon)
                {
                    weapon.gameObject.SetActive(true);
                    _animator.runtimeAnimatorController = currentWeapon.attackSO._animatorOveride;
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
                
            
            }
        }
    }

}
