using GameCore.Character;
using System;
using UnityEngine;

namespace GameCore.AI
{
    public class AttackState : IState
    {
        private readonly ICharacterMover mover;
        private readonly ICharacterCombat combat;
        private readonly Func<Transform> getTargetFunc;
        private Transform currentTarget;

        public AttackState(ICharacterMover mover, ICharacterCombat combat, Func<Transform> getTargetFunc)
        {
            this.mover = mover;
            this.combat = combat;
            this.getTargetFunc = getTargetFunc;
        }

        public void Tick()
        {
            mover.TurnTowards(currentTarget.position);
            combat.Attack();
        }

        public bool IsFinished()
        {
            return currentTarget == null;
        }

        public void OnEnter()
        {
            currentTarget = getTargetFunc();
        }

        public void OnExit()
        {

        }
    }
}