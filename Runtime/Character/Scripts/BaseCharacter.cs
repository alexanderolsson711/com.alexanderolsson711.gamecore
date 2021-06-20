using UnityEngine;

namespace GameCore.Character
{
    public abstract class BaseCharacter : MonoBehaviour, ICharacter
    {
        protected ICharacterAnimator animator;
        protected ICharacterCombat combat;
        protected ICharacterMover mover;

        protected virtual void Awake()
        {
            animator = new BaseCharacterAnimator(GetComponentInChildren<Animator>());
            combat = GetComponent<ICharacterCombat>();
        }

        public abstract void Died();

        public ICharacterAnimator GetCharacterAnimator()
        {
            return animator;
        }

        public ICharacterCombat GetCharacterCombat()
        {
            return combat;
        }

        public ICharacterMover GetCharacterMover()
        {
            return mover;
        }
    }
}
