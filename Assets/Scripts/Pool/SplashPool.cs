using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;


namespace Pool
{
    public class SplashPool : Singleton<SplashPool>
    {
        [SerializeField] private PoolSettingsScriptableObject poolSettings;

        private Queue<GameObject> itemPoolQueue;

        public Transform SpawnFromPool(Vector3 position, Quaternion rotation)
        {
            var objectSpawned = itemPoolQueue.Dequeue();
            objectSpawned.SetActive(true);
        
            var objectSpawnedTransform = objectSpawned.transform;
            objectSpawnedTransform.position = position;
            objectSpawnedTransform.rotation = rotation;

            itemPoolQueue.Enqueue(objectSpawned);
            
            return objectSpawnedTransform;
        }

        public void InitializeItemPoolDict()
        {
            itemPoolQueue = new Queue<GameObject>(poolSettings.PoolSize);
            
            InitializeItemPool(poolSettings.PoolSize, itemPoolQueue);
        }
   
        private void InitializeItemPool(int poolSize, Queue<GameObject> newItemPool)
        {
            for (var j = 0; j < poolSize; j++)
            {
                var obj = Instantiate(poolSettings.ItemTransform, new Vector3(0f, -100f, 0f), Quaternion.identity,
                    gameObject.transform).gameObject;
                obj.SetActive(false);
                newItemPool.Enqueue(obj);
            }
        }

        private void OnDisable()
        {
            itemPoolQueue = null;
        }
    }
}