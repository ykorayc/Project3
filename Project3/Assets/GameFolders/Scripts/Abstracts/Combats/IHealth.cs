using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Abstracts.Combats
{
    public interface IHealth
    {
        bool isDead { get; }
        void TakeDamage(int damage);
        
    }

}
