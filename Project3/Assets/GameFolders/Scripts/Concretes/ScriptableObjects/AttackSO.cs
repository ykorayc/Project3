using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Combats;
using Project3.Combats;
namespace Project3.ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "Attack Info",menuName = "Combat/Attack Information/Create New", order =2)]
    public class AttackSO : ScriptableObject
    {
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
        
    }

}
