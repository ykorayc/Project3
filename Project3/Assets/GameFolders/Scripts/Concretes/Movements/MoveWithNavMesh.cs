using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Movements;
using UnityEngine.AI;
using Project3.Controllers;
using Project3.Abstracts.Controllers;
namespace Project3.Movements
{

    public class MoveWithNavMesh : IMover
    {
        NavMeshAgent _navMesh;

        public MoveWithNavMesh(IEntityController entityController)
        {
            _navMesh = entityController.transform.GetComponent<NavMeshAgent>(); //Zaten bu kismi MoveWithNavMesh'i cagirdigimiz kisimda verecegiz.(EnemyController'i ctor'da verecegiz.(Nesne olustururken.))
        }
        public void MoveAction(Vector3 direction, float moveSpeed)
        {
           // _navMesh.speed = moveSpeed;
            _navMesh.SetDestination(direction);
        }
    }

}
