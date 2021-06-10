
namespace GameCore.Character
{
    public interface ICharacterAnimator
    {
        void SetMovementSpeed(float speed);
        void PlayAttack();
        void PlayHurt();
        void PlayDeath();
    }
}
