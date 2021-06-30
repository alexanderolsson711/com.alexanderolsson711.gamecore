using GameCore.Character;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.AI
{
    public class PriorityDistanceAttackDecision : PriorityDecision
    {
        public PriorityDistanceAttackDecision(ICharacterMover mover, ICharacterCombat combat, Func<Transform> targetFunc, float priorityFactor = 1, List<Func<bool>> extraConds = null) :
            base(() => PriorityHelper.DistancePriority(mover.GetTransform(), targetFunc(), priorityFactor), new AttackState(mover, combat, targetFunc), extraConds)
        { }
    }
}

