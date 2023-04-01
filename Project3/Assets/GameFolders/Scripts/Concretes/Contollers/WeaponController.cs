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
       
        float currentTime = 0.0f;
        IAttackType _attackType;
        LayerMask _layerMask;

        public AnimatorOverrideController AnimatorOverride=>_attackType.AttackInfo._animatorOveride;
        private void Awake()
        {
            _attackType = GetComponent<IAttackType>();
        }
       
        private void Update()
        {
            currentTime += Time.deltaTime;
            _canFire = currentTime > _attackType.AttackInfo._attackMaxDelay;
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
         //   _attackType.AttackAction();
        }
       

        }
}

