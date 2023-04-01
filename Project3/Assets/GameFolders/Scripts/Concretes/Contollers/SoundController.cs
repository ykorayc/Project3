using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Managers;
namespace Project3.Controllers
{
    public class SoundController : MonoBehaviour
    {
        AudioSource _audioSource;
        public bool isPlaying => _audioSource.isPlaying;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public void SetClip(AudioClip clip)
        {

            if (clip == _audioSource.clip) return;
            _audioSource.clip = clip;
            //_audioSource.Play();
        }
        public void PlaySound(Vector3 position)
        {
            transform.position = position;
            _audioSource.Play();
        }
    }

}
