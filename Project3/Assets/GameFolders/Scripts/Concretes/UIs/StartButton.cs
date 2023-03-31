using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Managers;
using UnityEngine.UI;
namespace Project3.UIs
{
    public class StartButton : MonoBehaviour
    {
        Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        //onClick metodunu bu sekilde kodla da verebiliriz, el ile de atayabiliriz arayuzu kullanarak.
        private void OnEnable() 
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }
        private void HandleOnButtonClicked()
        {
            GameManager.instance.LoadLevel("Game");
        }
    }

}
