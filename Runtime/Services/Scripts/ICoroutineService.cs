using System.Collections;
using UnityEngine;

namespace GameCore.Services
{
    public interface ICoroutineService : IService
    {
        Coroutine BeginCoroutine(IEnumerator coroutine);
        Coroutine PerformAfterSeconds(System.Action action, float seconds);
    }
}