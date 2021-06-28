using System;
using System.Collections.Generic;
using GameCore.Character;
using UnityEngine;

namespace GameCore.Helpers
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterTrigger : MonoBehaviour
    {
        private List<Action<ICharacter>> listeners = new List<Action<ICharacter>>();

        public void AddListener(Action<ICharacter> listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(Action<ICharacter> listener)
        {
            listeners.Remove(listener);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICharacter character))
            {
                listeners.ForEach(listener => listener(character));
            }
        }
    }
}
