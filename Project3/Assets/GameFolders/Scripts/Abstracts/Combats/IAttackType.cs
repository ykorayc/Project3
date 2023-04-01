using Project3.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Abstracts.Combats
{
    public interface IAttackType
    {
        void AttackAction();
        public AttackSO AttackInfo { get; }
    }
}
