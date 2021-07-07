using UnityEngine;

namespace GameCore.Character
{
    public interface ICharacterMover
    {
        void MoveTo(Vector3 position);
        void MoveTowards(Vector3 direction);
        void TurnTowards(Vector3 point);
        void Rotate(Vector3 euler);
        void TeleportTo(Vector3 position);
        void Stop();
        Transform GetTransform();
    }
}