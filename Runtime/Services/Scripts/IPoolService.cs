using UnityEngine;

namespace GameCore.Services
{
    public interface IPoolService : IService
    {
        GameObject Get(GameObject prefab);
        void Pool(GameObject obj);
    }
}