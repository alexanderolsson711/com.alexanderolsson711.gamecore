using UnityEngine;

namespace GameCore.Character
{
    public class BaseCharacterAnimator : ICharacterAnimator
    {
        private readonly Animator animator;
        private readonly CharacterAnimationInfo animationInfo;

        private readonly float moveAnimationSpeed;
        private readonly float attackAnimationLength;

        private readonly int attackHash;
        private readonly int deathHash;
        private readonly int hurtHash;
        private readonly int movementSpeedHash;
        private readonly int attackSpeedHash;

        public BaseCharacterAnimator (CharacterStats stats, CharacterAnimationInfo animationInfo, Animator animator)
        {
            this.animator = animator;
            this.animationInfo = animationInfo;
            moveAnimationSpeed = animationInfo.MoveAnimationSpeed;
            attackAnimationLength = animationInfo.AttackAnimationLength;

            attackHash = Animator.StringToHash("Attack");
            deathHash = Animator.StringToHash("Death");
            hurtHash = Animator.StringToHash("Hurt");
            movementSpeedHash = Animator.StringToHash("MovementSpeed");
            attackSpeedHash = Animator.StringToHash("AttackSpeed");

            SetAttackSpeed(stats.AttackSpeed);
        }

        public CharacterAnimationInfo GetCharacterAnimationInfo()
        {
            return animationInfo;
        }

        public void PlayAttack()
        {
            animator.SetTrigger(attackHash);
        }

        public void PlayDeath()
        {
            animator.SetTrigger(deathHash);
        }

        public void PlayHurt()
        {
            animator.SetTrigger(hurtHash);
        }

        public void SetMovementSpeed(float speed)
        {
            animator.SetFloat(movementSpeedHash, Mathf.Abs(speed) * moveAnimationSpeed);
        }

        public void SetAttackSpeed(float speed)
        {
            animator.SetFloat(attackSpeedHash, Mathf.Abs(speed) * attackAnimationLength);
        }
    }
}