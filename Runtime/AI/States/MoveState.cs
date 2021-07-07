using System;
using UnityEngine;
using GameCore.Character;
using GameCore.Helpers;

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

        public void Tick() 
        {
            mover.MoveTo(currentDestination);
        }

        public bool IsFinished()
        {
            return CharacterDistances.DistanceTo(mover, currentDestination) <= arrivedTresh;
        }

        public void OnEnter()
        {
            currentDestination = getDestinationFunc();
        }

        public void OnExit()
        {
            mover.Stop();
        }
    }
}
