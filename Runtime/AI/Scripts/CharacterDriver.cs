using GameCore.Character;
using UnityEngine;

namespace GameCore.AI
{
    [RequireComponent(typeof(ICharacter))]
    public abstract class CharacterDriver : MonoBehaviour
    {
        #region character
        protected ICharacter character;
        protected ICharacterMover mover;
        protected ICharacterCombat combat;
        protected Transform characterTransform;
        #endregion

        protected StateMachine stateMachine;

        protected virtual void Start()
        {
            GetCharacter();
            SetupStateMachine();
        }
        private void GetCharacter()
        {
            character = GetComponent<ICharacter>();
            combat = character.GetCharacterCombat();
            mover = character.GetCharacterMover();
            characterTransform = mover.GetTransform();
        }

        protected abstract void SetupStateMachine();

        protected virtual void Update()
        {
            UpdateTargets();
            stateMachine.Tick();
        }

        protected abstract void UpdateTargets();
    }
}
