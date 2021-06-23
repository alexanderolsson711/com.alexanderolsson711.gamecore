using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Combat
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class HurtableColliderContainer : MonoBehaviour
    {
        public HashSet<IHurtable> HurtablesInside => hurtablesInside;

        private readonly HashSet<IHurtable> hurtablesInside = new HashSet<IHurtable>();

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IHurtable hurtable))
            {
                hurtablesInside.Add(hurtable);
                hurtable.AddOnDestroyListener(h => hurtablesInside.Remove(h));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (TryGetComponent(out IHurtable hurtable))
            {
                hurtablesInside.Remove(hurtable);
            }
        }
    }
}
