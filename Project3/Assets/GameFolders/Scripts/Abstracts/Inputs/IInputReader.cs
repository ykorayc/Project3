using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Abstracts.Inputs
{
    public interface IInputReader
    {
        Vector3 direction { get; }
        Vector2 rotation { get; }
        bool isAttackButtonPress { get; }
    }

}
