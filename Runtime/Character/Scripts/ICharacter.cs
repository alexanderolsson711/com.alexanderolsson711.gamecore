
namespace GameCore.Character
{
    public interface ICharacter
    {
        void Died();
        ICharacterAnimator GetCharacterAnimator();
        ICharacterCombat GetCharacterCombat();
        ICharacterMover GetCharacterMover();

    }
}