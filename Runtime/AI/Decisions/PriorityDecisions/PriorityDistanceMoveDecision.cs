using GameCore.Character;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.AI
{
    public class PriorityDistanceMoveDecision : PriorityDecision
    {
        public PriorityDistanceMoveDecision(ICharacterMover mover, Func<Vector3> positionFunc, float arriveTresh = 1, float priorityFactor = 1, List<Func<bool>> extraConds = null) :
            base(() => PriorityHelper.DistancePriority(mover.GetTransform(), positionFunc(), priorityFactor), new MoveState(mover, positionFunc, arriveTresh), extraConds)
        { }
    }
}
