using System.Collections;
using UnityEngine;

namespace GameCore.Services
{
    public class CoroutineService : BaseMonoService, ICoroutineService
    {
        protected override void RegisterService()
        {
            locator.Register<ICoroutineService>(this);
        }

        protected override void UnregisterService()
        {
            locator.Unregister<ICoroutineService>();
        }

        public Coroutine BeginCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public Coroutine PerformAfterSeconds(System.Action action, float seconds)
        {
            return StartCoroutine(PerformAfterSecondsRoutine(action, seconds));
        }

        private IEnumerator PerformAfterSecondsRoutine(System.Action action, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            action.Invoke();
        }
    }
}
