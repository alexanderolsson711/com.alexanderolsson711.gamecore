using UnityEngine;

namespace GameCore.Character
{
    [CreateAssetMenu(fileName = "AnimationInfo", menuName = "GameCore/Character/AnimatorInfo")]
    public class CharacterAnimationInfo : ScriptableObject
    {
        public float MoveAnimationSpeed => moveAnimationSpeed;
        public float AttackAnimationLength => attackAnimationLength;
        public float AttackAnimationDelay => attackAnimationDelay;

        [SerializeField]
        private float moveAnimationSpeed = 1;

        [SerializeField]
        private float attackAnimationLength = 1;

        [SerializeField]
        private float attackAnimationDelay = 0.5f;

    }
}
