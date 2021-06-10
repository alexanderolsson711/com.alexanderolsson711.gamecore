using UnityEngine;

namespace GameCore.Character
{
    public abstract class BaseCharacterCombat : ICharacterCombat
    {
        protected ICharacter character;
        protected ICharacterAnimator animator;
        protected int health;
        protected int attackDmg;
        protected float attackDelay;
        protected float attackColdown;
        private float lastAttackTime;

        public BaseCharacterCombat(ICharacter character, int startHealth, int attackDmg, float attackDelay, float attackColdown)
        {
            this.character = character;
            animator = character.GetCharacterAnimator();
            health = startHealth;
            this.attackDmg = attackDmg;
            this.attackDelay = attackDelay;
            this.attackColdown = attackColdown;
        }

        public virtual void Attack()
        {
            if (Time.time - lastAttackTime >= attackColdown)
            {
                lastAttackTime = Time.time;
                animator.PlayAttack();
                // TODO: Add coroutine for attack delay
                DoAttack();
            }
            
        }

        public virtual void Hurt(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                character.Died();
            }
            else
            {
                animator.PlayHurt();
            }
        }

        protected abstract void DoAttack();

    }
}
