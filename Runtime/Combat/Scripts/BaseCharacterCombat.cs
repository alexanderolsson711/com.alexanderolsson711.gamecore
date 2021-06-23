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
        [SerializeField]
        protected int startHealth = 1;
        [SerializeField]
        protected int attackDmg = 1;
        [SerializeField]
        protected float attackDelay = 1;
        [SerializeField]
        protected float attackColdown = 2;
        #endregion

        protected ICharacter character;
        protected ICharacterAnimator animator;

        protected int health = 1;
        private float lastAttackTime;

        private void Start()
        {
            character = GetComponent<ICharacter>();
            animator = character.GetCharacterAnimator();
            health = startHealth;
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

        private IEnumerator WaitForAttack()
        {
            yield return new WaitForSeconds(attackColdown);
            DoAttack();
        }

        protected abstract void DoAttack();

        public void AddOnDestroyListener(Action<IHurtable> listener)
        {
            character.AddOnDiedListener(c => listener(this));
        }
    }
}
