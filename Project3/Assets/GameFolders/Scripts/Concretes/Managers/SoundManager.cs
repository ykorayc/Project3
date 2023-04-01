using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Helpers;
using Project3.Controllers;

namespace Project3.Managers
{
    public class SoundManager : SingletonMonobehavior<SoundManager>
    {
        [SerializeField] AudioClip _clip;
        SoundController[] _soundControllers;
        public SoundController[] SoundControllers => _soundControllers;
        private void Awake()
        {
            SetSingletonThisObject(this);
            _soundControllers = GetComponentsInChildren<SoundController>();
        }
        private void Start()
        {
            _soundControllers[0].SetClip(_clip);
            _soundControllers[0].PlaySound(Vector3.zero);
        }
        public void RangeAttackSound(AudioClip clip,Vector3 position)
        {

                _soundControllers[1].PlaySound(position);
                _soundControllers[1].SetClip(clip);
            
            
        }
        public void MeleeAttackSound(AudioClip clip,Vector3 position)
        {
            for(int i = 2; i < _soundControllers.Length; i++)
            {
                if (_soundControllers[i].isPlaying) continue;

                _soundControllers[i].SetClip(clip);
                _soundControllers[i].PlaySound(position);
                break;
            }
        }
    }

}
