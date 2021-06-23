using UnityEngine;

namespace GameCore.Character
{
    public class BaseCharacterAnimator : ICharacterAnimator
    {
        private Animator animator;

        private int attackHash;
        private int deathHash;
        private int hurtHash;
        private int speedHash;

        public BaseCharacterAnimator (Animator animator)
        {
            this.animator = animator;
            attackHash = Animator.StringToHash("Attack");
            deathHash = Animator.StringToHash("Death");
            hurtHash = Animator.StringToHash("Hurt");
            speedHash = Animator.StringToHash("Speed");
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
            animator.SetFloat(speedHash, Mathf.Abs(speed));
        }
    }
}