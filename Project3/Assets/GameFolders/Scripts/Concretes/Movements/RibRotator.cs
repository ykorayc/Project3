using Project3.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Project3.Movements
{
    public class RibRotator : IRotator
    {
        Transform _transform;
        float _tilt;
        public RibRotator(Transform transform)
        {
            _transform = transform;
        }
        public void RotationAciton(float direction, float turnSpeed)
        {
            direction *= turnSpeed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt-direction,-30f,30f);
            _transform.Rotate(new Vector3(0f,0f,_tilt));
        }
    }

}
