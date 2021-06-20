using System;
using System.Collections.Generic;

namespace GameCore.AI
{
    public class ConditionDecisionMaker : IDecisionMaker
    {
        private readonly List<StateConditionPair> stateConditionPairs;

        public ConditionDecisionMaker()
        {
            stateConditionPairs = new List<StateConditionPair>();
        }

        public IState GetNextState()
        {
            StateConditionPair next = stateConditionPairs.Find(pair => pair.Condition() == true);
            return next != null ? next.State : null;
        }

        public void AddConditionState(Func<bool> condition, IState state)
        {
            stateConditionPairs.Add(new StateConditionPair(condition, state));
        }

        private class StateConditionPair
        {
            public Func<bool> Condition { get; private set; }

            public IState State { get; private set; }

            public StateConditionPair(Func<bool> condition, IState state)
            {
                Condition = condition;
                State = state;
            }
        }
    }
}
