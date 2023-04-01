using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Combats;
using Project3.ScriptableObjects;
using Project3.Managers;

namespace Project3.Combats
{
    public class MeleeAttackType :MonoBehaviour, IAttackType
    {
        [SerializeField] Transform _transformObject;
        [SerializeField] AttackSO _attackSO;

        public AttackSO AttackInfo => _attackSO;

        public void AttackAction()
        {
            Vector3 attackPoint = _transformObject.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint,_attackSO._floatValue,_attackSO._layerMask);
            foreach (Collider collider in colliders)
            {
                if(collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO._damage);
                }
            }
            SoundManager.instance.MeleeAttackSound(_attackSO._clip,_transformObject.position);
        }
       
    }

}
