using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
        [SerializeField] float _attackMaxDelay;
        [SerializeField] Camera _camera;
        [SerializeField] float distance;
        [SerializeField] LayerMask _layerMask;
        float currentTime = 0.0f;
       
        private void Update()
        {
            currentTime += Time.deltaTime;
            _canFire = currentTime > _attackMaxDelay;

        }
        public void Atack()
        {
            if (!_canFire) return;
            currentTime = 0f;
            Ray _ray = _camera.ViewportPointToRay(Vector3.one / 2);//Tam orta nokta.
            if(Physics.Raycast(_ray,out RaycastHit hit,distance,_layerMask))
            {
                Debug.Log(hit.transform.name);
            }

        }
    }

}