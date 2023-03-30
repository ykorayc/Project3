using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Project3.ScriptableObjects;
namespace Project3.Helpers
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        [SerializeField] float radius;
        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position,radius);
        }
    }

}
