using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Abstracts.Helpers
{
    public abstract class SingletonMonobehavior<T> : MonoBehaviour where T : Component
    {
        public static T instance { get; private set; }

        protected void SetSingletonThisObject(T entity)
        {
            if (instance == null)
            {
                instance = entity;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(instance);
            }
        }
    }
}
