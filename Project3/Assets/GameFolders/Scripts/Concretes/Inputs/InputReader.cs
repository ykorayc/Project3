using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Project3.Abstracts.Inputs;
namespace Project3.Inputs
{
    public class InputReader : MonoBehaviour,IInputReader
    {

        public Vector3 direction { get; private set; }
        public Vector2 rotation { get; private set; }

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

    }

}
