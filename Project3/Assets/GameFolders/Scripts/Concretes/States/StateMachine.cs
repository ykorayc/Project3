using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Project3.Abstracts.States;

namespace Project3.States
{
    public class StateMachine 
    {
        List<StateTransformer> _stateTransformers = new List<StateTransformer>();
        List<StateTransformer> _anyStateTransformer = new List<StateTransformer>();
        IState _currentState;

        public void SetState(IState state)
        {
            if (_currentState == state) return;
            _currentState?.OnExit(); //nulL degilse OnExit'i calistir demek.
            _currentState = state;
            _currentState.OnEnter();
        }
        public void Tick()
        {
            StateTransformer stateTransformer = CheckForTransformer();
            if (stateTransformer!=null)
            {
                SetState(stateTransformer.To);
            }
            _currentState.Tick();
        }
        public void TickFixed()
        {
            _currentState.TickFixed();
        }
        public void TickLate()
        {
            _currentState.TickLate();
        }
        private StateTransformer CheckForTransformer()
        {
            foreach (StateTransformer stateTransformer in _anyStateTransformer)
            {
                if (stateTransformer.Condition.Invoke()) return stateTransformer; //Condition true ise.
            }
            foreach(StateTransformer stateTransformer in _stateTransformers)
            {
                if (stateTransformer.Condition.Invoke() && _currentState == stateTransformer.From) return stateTransformer;
            }
            return null;
        }

        public void AddState(IState from, IState to,Func<bool> condition)
        {
            StateTransformer stateTransformer = new StateTransformer(from,to,condition);
            _stateTransformers.Add(stateTransformer);
        }
        public void AddAnyState(IState to,Func<bool> condition)
        {
            StateTransformer stateTransformer = new StateTransformer(null,to,condition);
            _anyStateTransformer.Add(stateTransformer);
        }
        
    }

}