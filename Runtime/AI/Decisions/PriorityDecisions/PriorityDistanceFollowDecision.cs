using GameCore.Character;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.AI
{
    public class PriorityDistanceFollowDecision : PriorityDecision
    {
        public PriorityDistanceFollowDecision(ICharacterMover mover, Func<Transform> targetFunc, float priorityFactor = 1, float arriveTresh = 1, List<Func<bool>> extraConds = null) :
            base(() => PriorityHelper.DistancePriority(mover.GetTransform(), targetFunc(), priorityFactor), new FollowState(mover, targetFunc, arriveTresh), extraConds)
        { }
    }
}

