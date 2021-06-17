using UnityEngine;

namespace GameCore.Services
{
    public static class ServiceBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initiailze()
        {
            ServiceLocator.Initiailze();
            ServiceLocator locator = ServiceLocator.Instance;

            locator.Register<IPoolService>(new PoolService());
        }
    }
}