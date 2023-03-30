using Project3.Abstracts.Controllers;
using Project3.Abstracts.Movements;
using Project3.Controllers;
using UnityEditor;
using UnityEngine;
using Project3.Animations;

namespace Project3.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get; }
        InventoryController Inventory { get; }
        CharacterAnimations Animation { get; }
        Transform Target { get; set; }
        float Magnitude { get; }
    }

}