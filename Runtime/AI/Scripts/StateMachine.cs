using System;
using System.Linq;
using System.Collections.Generic;

namespace GameCore.AI
{
    public class StateMachine
    {
        private readonly List<Func<bool>> conditions;
        private readonly IDecisionMaker decisionMaker;
        private IState currentState;

        public StateMachine(IDecisionMaker decisionMaker)
        {
            this.decisionMaker = decisionMaker;
            conditions = new List<Func<bool>>();
        }

        public void Tick()
        {
            if (currentState == null || conditions.Any(cond => cond()) || currentState.IsFinished())
            {
                ChangeCurrentState();
            }

            currentState?.Tick();
        }

        public void AddCondition(Func<bool> cond)
        {
            conditions.Add(cond);
        }

        private void ChangeCurrentState()
        {
            IState nextState = decisionMaker.GetNextState();
            if (nextState != currentState)
            {
                currentState?.OnExit();
                currentState = nextState;
                currentState?.OnEnter();
            }
        }
    }
}
