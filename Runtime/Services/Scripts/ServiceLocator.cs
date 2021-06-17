using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Services
{
    public class ServiceLocator
    {
        private readonly Dictionary<string, IService> services;

        public static ServiceLocator Instance { get; private set; }

        private ServiceLocator()
        {
            services = new Dictionary<string, IService>();
        }

        public static void Initiailze()
        {
            Instance = new ServiceLocator();
        }

        public bool TryGetService<T>(out T service) where T : IService
        {
            string key = typeof(T).Name;
            if (services.TryGetValue(key, out IService s))
            {
                service = (T)s;
                return true;
            }
            else
            {
                service = default(T);
                return false;
            }
        }

        public void Register<T>(T service) where T : IService
        {
            string key = typeof(T).Name;
            if (services.ContainsKey(key))
            {
                Debug.LogError($"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
                return;
            }
            services.Add(key, service);
        }

        public void Unregister<T>() where T : IService
        {
            string key = typeof(T).Name;
            if (!services.ContainsKey(key))
            {
                Debug.LogError($"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
                return;
            }
            services.Remove(key);
        }
    }
}