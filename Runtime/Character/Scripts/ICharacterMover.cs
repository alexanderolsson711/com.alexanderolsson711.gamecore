using UnityEngine;

namespace GameCore.Character
{
    public interface ICharacterMover
    {
        void MoveTo(Vector3 pos);
        void MoveTowards(Vector3 direction);
        void TurnTowards(Vector3 point);
        void Stop();
        Transform GetTransform();
    }
}