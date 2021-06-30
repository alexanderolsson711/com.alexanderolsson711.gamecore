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

        public AttackState(ICharacterMover mover, ICharacterCombat combat, Func<Transform> getTargetFunc)
        {
            this.mover = mover;
            this.combat = combat;
            this.getTargetFunc = getTargetFunc;
        }

        public void Tick()
        {
            mover.TurnTowards(getTargetFunc().position);
            combat.Attack();
        }

        public bool IsFinished()
        {
            return getTargetFunc() == null;
        }

        public void OnEnter()
        {
            
        }

        public void OnExit()
        {

        }
    }
}