using UnityEngine;
using GameCore.Character;
using System.Collections;
using System;

namespace GameCore.Combat
{
    [RequireComponent(typeof(ICharacter))]
    public abstract class BaseCharacterCombat : MonoBehaviour, ICharacterCombat, IHurtable
    {
        #region Stats
        protected int health;
        protected int attackDmg;
        protected float attackRange;
        protected float attackDelay;
        protected float attackColdown;
        #endregion

        protected ICharacter character;
        protected ICharacterAnimator animator;

        private float lastAttackTime;

        private void Start()
        {
            character = GetComponent<ICharacter>();
            animator = character.GetCharacterAnimator();
            SetupCombatStats(character.GetCharacterStats(), animator.GetCharacterAnimationInfo());
        }

        private void SetupCombatStats(CharacterStats stats, CharacterAnimationInfo animationInfo)
        {
            health = stats.StartHealth;
            attackDmg = stats.AttackDamage;
            attackRange = stats.AttackRange;
            attackColdown = 1 / stats.AttackSpeed;
            attackDelay = attackColdown * animationInfo.AttackAnimationDelay;
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

        public virtual void Attack()
        {
            if (Time.time - lastAttackTime >= attackColdown)
            {
                lastAttackTime = Time.time;
                animator.PlayAttack();
                StartCoroutine(WaitForAttack());
            }    
        }

        private IEnumerator WaitForAttack()
        {
            yield return new WaitForSeconds(attackDelay);
            DoAttack();
        }

        protected abstract void DoAttack();
    }
}
