using System;
using UnityEngine;
using GameCore.Character;

namespace GameCore.AI
{
    public class MoveState : IState
    {
        private readonly ICharacterMover mover;
        private readonly Func<Vector3> getDestinationFunc;
        private readonly float arrivedTresh = 1f;
        private Vector3 currentDestination;

        public MoveState(ICharacterMover mover, Func<Vector3> getDestinationFunc, float arrivedTresh = 1)
        {
            this.mover = mover;
            this.getDestinationFunc = getDestinationFunc;
            this.arrivedTresh = arrivedTresh;
        }

        public void Tick() { }

        public bool IsFinished()
        {
            return Vector3.Distance(mover.GetTransform().position, currentDestination) <= arrivedTresh;
        }

        public void OnEnter()
        {
            currentDestination = getDestinationFunc();
            mover.MoveTo(currentDestination);
        }

        public void OnExit()
        {
            mover.Stop();
        }
    }
}
