using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCore.AI
{
    public class PriorityDecisionMaker : IDecisionMaker
    {
        private readonly List<StatePriorityPair> statePriorityPairs;

        public PriorityDecisionMaker()
        {
            statePriorityPairs = new List<StatePriorityPair>();
        }

        public IState GetNextState()
        {
            StatePriorityPair pair = statePriorityPairs.OrderByDescending(p => p.Priority).First();
            return pair.Priority > 0 ? pair.State : null;
        }

        public void AddPriorityState(Func<float> priorityFunc, IState state)
        {
            statePriorityPairs.Add(new StatePriorityPair(priorityFunc, state));
        }

        private class StatePriorityPair
        {
            public float Priority => Mathf.Clamp(priorityFunc(), 0, 1);
            private readonly Func<float> priorityFunc;

            public IState State { get; private set; }

            public StatePriorityPair(Func<float> priorityFunc, IState state)
            {
                this.priorityFunc = priorityFunc;
                State = state;
            }
        }
    }
}
