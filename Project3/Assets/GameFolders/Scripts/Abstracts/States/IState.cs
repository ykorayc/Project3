using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Project3.Abstracts.States
{
    public interface IState 
    {
        void Tick();
        void OnExit();
        void OnEnter();
        void TickFixed();
        void TickLate();
    }

}
