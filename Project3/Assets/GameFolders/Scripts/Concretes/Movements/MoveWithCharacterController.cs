using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Movements;
using Project3.Controllers;
public class MoveWithCharacterController : IMover
{
    CharacterController _characterController;

    public MoveWithCharacterController(PlayerController playerController,float _moveSpeed)
    {
        _characterController = playerController.gameObject.GetComponent<CharacterController>();
    }

    public void MoveAction(Vector3 direction,float moveSpeed)
    {
        if (direction.magnitude == 0) return;

        //Eger local transform'umuzun direction'ýný world direction'a cevirmeseydik karakterimiz sola bakarken w'ye bassak bile w normalde nereyi gosteriyorsa oraya dogru hareket ederdi.
        //Bu sayede karakterimizin transformuna gore hareketi saglamis oluyoruz.
        //Yani karakterimiz saga bakarken w'ye basarsak sag tarafa gider vs...
        Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
        Vector3 movement = worldPosition * Time.deltaTime* moveSpeed;

        //  Vector3 movement = direction * Time.deltaTime;
        _characterController.Move(movement);
    }

}
