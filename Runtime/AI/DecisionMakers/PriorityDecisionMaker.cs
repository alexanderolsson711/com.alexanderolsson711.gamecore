using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCore.AI
{
    public class PriorityDecisionMaker : IDecisionMaker
    {
        private readonly List<PriorityDecision> priorityDecisions;

        public PriorityDecisionMaker(List<PriorityDecision> priorityDecisions = null)
        {
            this.priorityDecisions = priorityDecisions ?? new List<PriorityDecision>();
        }

        public IState GetNextState()
        {
            PriorityDecision pair = priorityDecisions.OrderByDescending(p => p.Priority).First();
            return pair.Priority > 0 ? pair.State : null;
        }

        public void AddPriorityDecision(Func<float> priorityFunc, IState state)
        {
            priorityDecisions.Add(new PriorityDecision(priorityFunc, state));
        }

        public void AddPriorityDecision(PriorityDecision decision)
        {
            priorityDecisions.Add(decision);
        }
    }
}
