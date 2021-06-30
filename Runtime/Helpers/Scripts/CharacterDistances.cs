using GameCore.Character;
using UnityEngine;

namespace GameCore.Helpers
{
    public static class CharacterDistances
    {
        #region Distance To
        public static float DistanceTo(ICharacter character, Vector3 position)
        {
            return DistanceTo(character.GetCharacterMover(), position);
        }

        public static float DistanceTo(ICharacterMover mover, Vector3 position)
        {
            return Vector3.Distance( mover.GetTransform().position, position);
        }

        public static float DistanceTo(ICharacter character, Transform transform)
        {
            return DistanceTo(character.GetCharacterMover(), transform.position);
        }

        public static float DistanceTo(ICharacterMover mover, Transform transform)
        {
            return Vector3.Distance(mover.GetTransform().position, transform.position);
        }
        #endregion

        #region Distance Within
        public static bool DistanceWithin(ICharacter character, Vector3 position, float value)
        {
            return DistanceTo(character, position) <= value;
        }

        public static bool DistanceWithin(ICharacterMover mover, Vector3 position, float value)
        {
            return DistanceTo(mover, position) <= value;
        }

        public static bool DistanceWithin(ICharacter character, Transform transform, float value)
        {
            return transform && DistanceWithin(character, transform.position, value); 
        }

        public static bool DistanceWithin(ICharacterMover mover, Transform transform, float value)
        {
            return transform && DistanceWithin(mover, transform.position, value);
        }
        #endregion

        #region Distance Beyond
        public static bool DistanceBeyond(ICharacter character, Vector3 position, float value)
        {
            return DistanceTo(character, position) > value;
        }

        public static bool DistanceBeyond(ICharacterMover mover, Vector3 position, float value)
        {
            return DistanceTo(mover, position) > value;
        }

        public static bool DistanceBeyond(ICharacter character, Transform transform, float value)
        {
            return transform && DistanceBeyond(character, transform.position, value);
        }

        public static bool DistanceBeyond(ICharacterMover mover, Transform transform, float value)
        {
            return transform && DistanceBeyond(mover, transform.position, value);
        }
        #endregion
    }
}
