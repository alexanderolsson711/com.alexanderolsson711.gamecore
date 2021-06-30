using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.AI
{
    public class StateMachine
    {
        private readonly List<Func<bool>> conditions;
        private readonly IDecisionMaker decisionMaker;
        private readonly float stateAutoCheckTime;

        private IState currentState;
        private float lastSwitchTime;

        public StateMachine(IDecisionMaker decisionMaker, float stateAutoCheckTime = 3)
        {
            this.decisionMaker = decisionMaker;
            conditions = new List<Func<bool>>();
            this.stateAutoCheckTime = stateAutoCheckTime;
        }

        public void Tick()
        {
            if (Time.time - lastSwitchTime >= stateAutoCheckTime  || currentState == null ||
                conditions.Any(cond => cond()) || currentState.IsFinished())
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
            lastSwitchTime = Time.time;
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
