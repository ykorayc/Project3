using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Combats;
using Project3.Combats;
using Project3.ScriptableObjects;
namespace Project3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
        [SerializeField] Transform transformObject;
       
        float currentTime = 0.0f;
        IAttackType _attackType;
        LayerMask _layerMask;

        [SerializeField] AttackSO _attackSO;
        private void Awake()
        {
            _attackType = _attackSO.GetAttackType(transformObject);
        }
        private void Update()
        {
            currentTime += Time.deltaTime;
            _canFire = currentTime > _attackSO._attackMaxDelay;
        }
        public void Atack()
        {
            if (!_canFire) return;
            _attackType.AttackAction();

            //birinci yol
            // IHealth health = hit.transform.GetComponent<IHealth>();
            // if(health!=null)
            // {
            //     health.TakeDamage(damage);
            // }
            currentTime = 0f;
            _attackType.AttackAction();
        }
       

        }
}

