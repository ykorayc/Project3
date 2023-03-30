using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Project3.Abstracts.Inputs;
namespace Project3.Inputs
{
    public class InputReader : MonoBehaviour,IInputReader
    {
        int _index;

        public Vector3 direction { get; private set; }
        public Vector2 rotation { get; private set; }
        public bool isAttackButtonPress{ get; private set; }

        public bool isInventoryButtonPressed { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 _olddirection = context.ReadValue<Vector2>();//Vector2 turunde olusturdugumuz icin value'yu vector2 turunde cekeriz.
            //Vector2 'yi Vector3'e cevirdik. Cok guzel bir cozum.
            direction = new Vector3(_olddirection.x,0,_olddirection.y);
        }
        public void OnRotator(InputAction.CallbackContext context)
        {
            rotation = context.ReadValue<Vector2>();
        }
        public void OnAttack(InputAction.CallbackContext context)
        {
            isAttackButtonPress = context.ReadValueAsButton();//bool deger aldigimizda ReadValueAsButton'u kullaniriz.
        }
        public void OnInventoryPressed(InputAction.CallbackContext context)
        {
            if (isInventoryButtonPressed && context.action.triggered) return;

            StartCoroutine(WaitOneFrameAsync());
            
            IEnumerator WaitOneFrameAsync()
            {
                isInventoryButtonPressed = true && _index % 2 == 0;
                yield return new WaitForEndOfFrame();
                isInventoryButtonPressed = false;
                _index++;
            }
            
        }
    }

}
