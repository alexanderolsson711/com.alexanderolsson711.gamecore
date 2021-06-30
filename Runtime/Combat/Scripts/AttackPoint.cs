using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCore.Combat
{
    public class AttackPoint : MonoBehaviour
    {
        [SerializeField]
        private float attackPointRadius = 0.5f;

        public List<IHurtable> GetHurtables()
        {
            return Physics.OverlapSphere(transform.position, attackPointRadius).Select(c => c.GetComponent<IHurtable>()).Where(h => h != null).ToList();
        }
    }
}
