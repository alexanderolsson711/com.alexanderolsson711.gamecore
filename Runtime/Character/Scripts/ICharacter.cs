using System;

namespace GameCore.Character
{
    public interface ICharacter
    {
        void Died();
        void AddOnDiedListener(Action<ICharacter> listener);
        ICharacterAnimator GetCharacterAnimator();
        ICharacterCombat GetCharacterCombat();
        ICharacterMover GetCharacterMover();

    }
}