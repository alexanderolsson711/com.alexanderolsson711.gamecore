using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Services
{
    public class PoolService : IPoolService
    {
        private readonly Dictionary<string, Queue<GameObject>> poolsDict;
        private readonly Dictionary<string, GameObject> prefabDict;
        private readonly Dictionary<string, Transform> parentDict;

        public PoolService()
        {
            poolsDict = new Dictionary<string, Queue<GameObject>>();
            prefabDict = new Dictionary<string, GameObject>();
            parentDict = new Dictionary<string, Transform>();
        }

        public GameObject Get(GameObject prefab)
        {
            string objName = prefab.name;
            if (!poolsDict.TryGetValue(objName, out Queue<GameObject> pool))
            {
                pool = new Queue<GameObject>();
                poolsDict.Add(objName, pool);
                prefabDict.Add(objName, prefab);
                parentDict.Add(objName, new GameObject(objName + "s").transform);
            }
            return GetFromPool(objName, pool);
        }

        public void Pool(GameObject obj)
        {
            string objName = obj.name.Replace("(Clone)", string.Empty);
            if (poolsDict.TryGetValue(objName, out Queue<GameObject> pool))
            {
                obj.SetActive(false);
                pool.Enqueue(obj);
            }
            else
            {
                Debug.LogError($"Tried to pool {objName} to pools, but no existing pool with that name.");
            }
        }

        private GameObject GetFromPool(string objName, Queue<GameObject> pool)
        {
            GameObject obj = pool.Count > 0 ? pool.Dequeue() : Object.Instantiate(prefabDict[objName], parentDict[objName]);
            obj.GetComponent<IPooledObject>().Pool();
            obj.SetActive(true);
            return obj;
        }
    }
}