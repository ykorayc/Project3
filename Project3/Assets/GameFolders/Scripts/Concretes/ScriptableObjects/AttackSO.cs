using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Combats;
using Project3.Combats;
namespace Project3.ScriptableObjects
{
    enum AttackTypeEnum:byte  //byte'tan miras almasi demek 0 ile 255 arasindaki tam sayilar icerebilecegini gosterir.
    {
        Range,
        Melee
    }
    [CreateAssetMenu(fileName = "Attack Info",menuName = "Combat/Attack Information/Create New", order =2)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] AttackTypeEnum _attackType;
        [SerializeField] float floatValue;
        [SerializeField] LayerMask layerMask;
        [SerializeField] int damage;
        [SerializeField] float attackMaxDelay;
        [SerializeField] AnimatorOverrideController animatorOveride;
        [SerializeField] AudioClip clip;

        public float _floatValue => floatValue;
        public LayerMask _layerMask => layerMask;
        public int _damage => damage;
        public float _attackMaxDelay => attackMaxDelay;
        public AnimatorOverrideController _animatorOveride => animatorOveride;
        public AudioClip _clip => clip;
        public IAttackType GetAttackType(Transform transform)
        {
            if (_attackType == AttackTypeEnum.Range)
            {
                return new RangeAttackType(transform,this);
            }
            else
            {
                return new MeleeAttackType(transform,this);
            }
        }
    }

}
