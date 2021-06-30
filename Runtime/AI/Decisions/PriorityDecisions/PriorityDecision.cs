using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCore.AI
{
    public class PriorityDecision
    {
        public float Priority => extraConds.All(c => c()) ? Mathf.Clamp(priorityFunc(), 0, 1) : 0;
        private readonly Func<float> priorityFunc;
        private readonly List<Func<bool>> extraConds;

        public IState State { get; private set; }

        public PriorityDecision(Func<float> priorityFunc, IState state, List<Func<bool>> extraConds = null)
        {
            this.priorityFunc = priorityFunc;
            this.extraConds = extraConds ?? new List<Func<bool>>();
            State = state;
        }

        public PriorityDecision(Func<float> priorityFunc, IState state, Func<bool> extraCond)
        {
            this.priorityFunc = priorityFunc;
            extraConds = new List<Func<bool>>() { extraCond };
            State = state;
        }
    }
}

