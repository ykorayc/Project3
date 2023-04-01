using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Helpers;
using UnityEngine.SceneManagement;
namespace Project3.Managers
{
    public class GameManager : SingletonMonobehavior<GameManager>
    {
        [SerializeField] int _waveLevel = 1;
        [SerializeField] float _waitNextLevet = 10.0f;
        [SerializeField] int maxWaveBoundaryCount = 50;
        [SerializeField] float _waveMultiple = 1.2f;

        public bool isWaveFinished => _curentWaveMaxCount <= 0;

        int _curentWaveMaxCount ;

        public event System.Action<int> OnNextWave;

        private void Awake()
        {
            SetSingletonThisObject(this);
        }
        private void Start()
        {
            _curentWaveMaxCount = maxWaveBoundaryCount;
        }
        public void LoadLevel(string name)
        {
            StartCoroutine(LoadLevelSceneAsync(name));
        }
        private IEnumerator LoadLevelSceneAsync(string name)
        {
           yield return SceneManager.LoadSceneAsync(name);
        }

        public void DecreaseWaveCount()
        {
            if (isWaveFinished)
            {
                if (EnemyManager.instance.IsListEmpty)
                {
                    StartCoroutine(StartNextWaveAsync());
                }
             
            }
            else
            {
                _curentWaveMaxCount--;
            }
         
        }
        private IEnumerator StartNextWaveAsync()
        {
            yield return new WaitForSeconds(_waitNextLevet);
            maxWaveBoundaryCount *= System.Convert.ToInt32(maxWaveBoundaryCount*_waveMultiple);
            _curentWaveMaxCount = maxWaveBoundaryCount;
            _waveLevel++;
            OnNextWave?.Invoke(_waveLevel);
        }
    }

}
