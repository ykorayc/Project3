using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Managers;
using TMPro;
namespace Project3.UIs
{
    public class DisplayWaveLevel : MonoBehaviour
    {
        TextMeshProUGUI _levelText;
        private void Awake()
        {
            _levelText = GetComponent<TextMeshProUGUI>();
        }
        private void OnEnable()
        {
            GameManager.instance.OnNextWave += HandleOnNextWave;
        }
        private void OnDisable()
        {
            GameManager.instance.OnNextWave -= HandleOnNextWave;
        }
        private void HandleOnNextWave(int levelValue)
        {
            _levelText.text = levelValue.ToString();
        }

    }
    

}
