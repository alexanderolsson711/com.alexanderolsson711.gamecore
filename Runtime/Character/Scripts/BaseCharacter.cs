using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Character
{
    public abstract class BaseCharacter : MonoBehaviour, ICharacter
    {
        protected List<Action<ICharacter>> onDiedListeners;

        protected ICharacterAnimator animator;
        protected ICharacterCombat combat;
        protected ICharacterMover mover;

        protected virtual void Awake()
        {
            onDiedListeners = new List<Action<ICharacter>>();
            animator = new BaseCharacterAnimator(GetComponentInChildren<Animator>());
            combat = GetComponent<ICharacterCombat>();
        }

        public abstract void Died();

        public void AddOnDiedListener(Action<ICharacter> listener)
        {
            onDiedListeners.Add(listener);
        }

        protected void InvokeOnDiedListeners()
        {
            onDiedListeners.ForEach(l => l(this));
        }

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
