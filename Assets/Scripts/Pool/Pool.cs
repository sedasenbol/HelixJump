using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class Pool<T> : Singleton<Pool<T>> where T : Transform
    {
        [SerializeField] private PoolSettingsScriptableObject poolSettings;
        [SerializeField] private Transform itemTransform;
        [SerializeField] private Transform itemContainerTransform;
        
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
        
        private void InitializeItemPoolDict()
        {
            itemPoolQueue = new Queue<GameObject>(poolSettings.PoolSize);
            
            InitializeItemPool(poolSettings.PoolSize, itemPoolQueue);
        }
   
        private void InitializeItemPool(int poolSize, Queue<GameObject> newItemPool)
        {
            for (var j = 0; j < poolSize; j++)
            {
                var obj = Instantiate(itemTransform, itemContainerTransform).gameObject;
                obj.SetActive(false);
                newItemPool.Enqueue(obj);
            }
        }

        private void OnEnable()
        {
            InitializeItemPoolDict();
        }

        private void OnDisable()
        {
            itemPoolQueue = null;
        }
    }
}

