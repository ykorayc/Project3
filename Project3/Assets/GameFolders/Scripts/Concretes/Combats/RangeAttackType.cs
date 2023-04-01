using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Combats;
using Project3.ScriptableObjects;
using Project3.Managers;

namespace Project3.Combats
{
    public class RangeAttackType : IAttackType
    {
        Camera _camera;
        AttackSO _attackSO;
        public RangeAttackType(Transform transformObject, AttackSO attackSO)
        {
            _camera = transformObject.GetComponent<Camera>();
            _attackSO = attackSO;

        }
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
            SoundManager.instance.RangeAttackSound(_attackSO._clip,_camera.transform.position);
        }

    }
}
