using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.ScriptableObjects
{
    [CreateAssetMenu(fileName ="Health Info",menuName ="Combat/Health Information/Create New",order =1)]

    //Her bir veriyi tek tek olusturmaktansa ScriptableObject olusturup o datalari cekmek daha performanslidir.!!!
    public class HealthSO : ScriptableObject
    {
        [SerializeField] int maxHealth;
        public int _maxHealth => maxHealth;
    }

}