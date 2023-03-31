using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project3.Abstracts.Helpers;
using UnityEngine.SceneManagement;
namespace Project3.Managers
{
    public class GameManager : SingletonMonobehavior<GameManager>
    {
        private void Awake()
        {
            SetSingletonThisObject(this);
        }
        public void LoadLevel(string name)
        {
            StartCoroutine(LoadLevelSceneAsync(name));
        }
        private IEnumerator LoadLevelSceneAsync(string name)
        {
           yield return SceneManager.LoadSceneAsync(name);
        }
    }

}
