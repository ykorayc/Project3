using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Combats;
using Project3.ScriptableObjects;
using Project3.Managers;
using Project3.Controllers;

namespace Project3.Combats
{
    public class RangeAttackType : MonoBehaviour,IAttackType
    {
        [SerializeField] Camera _camera;
        [SerializeField] AttackSO _attackSO;
        [SerializeField] Transform _bulletPoint;
        [SerializeField] BulletFxController bulletFx;
        public AttackSO AttackInfo => _attackSO;

        public void AttackAction()
        {
            Ray _ray = _camera.ViewportPointToRay(Vector3.one / 2);//Tam orta nokta.
            if (Physics.Raycast(_ray, out RaycastHit hit, _attackSO._floatValue, _attackSO._layerMask))
            {
                if (hit.collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO._damage);
                }
            }
            var bullet = Instantiate(bulletFx, _bulletPoint.position, _bulletPoint.rotation);
            bullet.SetDirection(_ray.direction);
            SoundManager.instance.RangeAttackSound(_attackSO._clip,_camera.transform.position);
        }

    }
}
