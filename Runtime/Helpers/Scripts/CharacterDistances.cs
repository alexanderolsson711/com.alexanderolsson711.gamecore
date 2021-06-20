using GameCore.Character;
using UnityEngine;

namespace GameCore.Helpers
{
    public static class CharacterDistances
    {
        public static float DistanceTo(Vector3 pos, ICharacter character)
        {
            return Vector3.Distance(pos, character.GetCharacterMover().GetTransform().position);
        }

        public static float DistanceTo(Vector3 pos, ICharacterMover mover)
        {
            return Vector3.Distance(pos, mover.GetTransform().position);
        }
    }
}
