using GameCore.Character;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Helpers
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterColliderContainer : MonoBehaviour
    {
        public HashSet<ICharacter> CharactersInside
        {
            get
            {
                charactersInside.RemoveWhere(c => c == null);
                return charactersInside;
            }
        }

        private readonly HashSet<ICharacter> charactersInside = new HashSet<ICharacter>();

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICharacter character))
            {
                charactersInside.Add(character);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (TryGetComponent(out ICharacter character))
            {
                charactersInside.Remove(character);
            }
        }
    }
}
