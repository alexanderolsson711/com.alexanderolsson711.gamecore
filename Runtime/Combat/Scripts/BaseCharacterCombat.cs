using UnityEngine;
using GameCore.Services;
using GameCore.Character;

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
        private ICoroutineService coroutineService;

        protected int health = 1;
        private float lastAttackTime;

        private void Start()
        {
            character = GetComponent<ICharacter>();
            animator = character.GetCharacterAnimator();
            health = startHealth;

            if (!ServiceLocator.Instance.TryGetService(out coroutineService))
            {
                coroutineService = null;
            }
        }

        public virtual void Attack()
        {
            if (Time.time - lastAttackTime >= attackColdown)
            {
                lastAttackTime = Time.time;
                animator.PlayAttack();
                if (coroutineService != null)
                {
                    coroutineService.PerformAfterSeconds(DoAttack, attackDelay);
                }
                else
                {
                    DoAttack();
                }
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
