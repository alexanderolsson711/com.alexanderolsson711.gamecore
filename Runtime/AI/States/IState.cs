using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.AI
{
    public interface IState
    {
        void Tick();
        bool IsFinished();
        void OnEnter();
        void OnExit();
    }
}
