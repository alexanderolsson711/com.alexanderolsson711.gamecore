
namespace GameCore.Character
{
    public interface ICharacterAnimator
    {
        CharacterAnimationInfo GetCharacterAnimationInfo();
        void PlayAttack();
        void PlayHurt();
        void PlayDeath();
        void SetMovementSpeed(float speed);
        void SetAttackSpeed(float speed);
    }
}
