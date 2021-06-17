using UnityEngine;

namespace GameCore.Services
{
    public abstract class BaseMonoService : MonoBehaviour, IService
    {
        protected ServiceLocator locator;

        protected virtual void Awake()
        {
            locator = ServiceLocator.Instance;
            if (locator != null)
            {
                RegisterService();
            }
            else
            {
                Debug.LogError("No Service Locator exists.");
            }
        }

        protected virtual void OnDestroy()
        {
            if (locator != null)
            {
                UnregisterService();
            }
        }

        protected abstract void RegisterService();
        protected abstract void UnregisterService();
    }
}