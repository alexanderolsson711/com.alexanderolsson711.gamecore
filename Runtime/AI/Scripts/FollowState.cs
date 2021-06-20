using System;
using UnityEngine;
using GameCore.Character;

namespace GameCore.AI
{
    public class FollowState : IState
    {
        private readonly ICharacterMover mover;
        private readonly Func<Transform> getTargetFunc;
        private readonly float arrivedTresh = 1f;
        private Transform currentTarget;

        public FollowState(ICharacterMover mover, Func<Transform> getTargetFunc, float arrivedTresh = 1)
        {
            this.mover = mover;
            this.getTargetFunc = getTargetFunc;
            this.arrivedTresh = arrivedTresh;
        }

        public void Tick()
        {
            mover.MoveTo(currentTarget.position);
        }

        public bool IsFinished()
        {
            return Vector3.Distance(mover.GetTransform().position, currentTarget.position) <= arrivedTresh;
        }

        public void OnEnter()
        {
            currentTarget = getTargetFunc();
        }

        public void OnExit()
        {
            mover.Stop();
        }
    }
}
