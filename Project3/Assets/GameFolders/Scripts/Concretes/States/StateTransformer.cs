using Project3.Abstracts.States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.States
{
    public class StateTransformer 
    {
        public IState To { get; }   //Sadece get dersek sadece erisilebilir ve ctor icerisinde degerlerini kontrol edebiliriz
                                //demek oluyor.
        public IState From { get; }
        public Func<bool> Condition { get; }
        public StateTransformer(IState from, IState to, Func<bool> condition)
        {
            To = to;
            From = from;
            Condition = condition;
        }
    }

}
