using System;
using UnityEngine;
using GameCore.Character;
using GameCore.Helpers;

namespace GameCore.AI
{
    public class FollowState : IState
    {
        private readonly ICharacterMover mover;
        private readonly Func<Transform> getTargetFunc;
        private readonly float arrivedTresh = 1f;

        public FollowState(ICharacterMover mover, Func<Transform> getTargetFunc, float arrivedTresh = 1)
        {
            this.mover = mover;
            this.getTargetFunc = getTargetFunc;
            this.arrivedTresh = arrivedTresh;
        }

        public void Tick()
        {
            mover.MoveTo(getTargetFunc().position);
        }

        public bool IsFinished()
        {
            Transform currentTarget = getTargetFunc();
            return currentTarget == null || CharacterDistances.DistanceTo(mover, currentTarget.position) <= arrivedTresh;
        }

        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            mover.Stop();
        }
    }
}
