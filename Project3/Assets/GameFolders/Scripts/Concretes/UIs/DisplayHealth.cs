using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Project3.Combats;
using System;
namespace Project3.UIs
{

    public class DisplayHealth : MonoBehaviour
    {
        Image _healthImage;

        private void Awake()
        {
            _healthImage = GetComponent<Image>();
        }
        private void OnEnable()
        {
            Health health = GetComponentInParent<Health>();
            health.OnTakeHit += TakingDamage;
        }
        //private void OnDisable()
        //{
        //    Health health = GetComponentInParent<Health>();
        //    health.OnTakeHit -= TakingDamage;
        //}
        private void TakingDamage(int currentHealth,int maxHealth)
        {
            _healthImage.fillAmount = Convert.ToSingle(currentHealth) / Convert.ToSingle(maxHealth);
        }
    }

}