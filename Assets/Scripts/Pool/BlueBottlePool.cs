using System;
using System.Collections.Generic;
using PickUps;
using ScriptableObjects;
using UnityEngine;

namespace Pool
{
    public class BlueBottlePool : Pool
    {
        private static BlueBottlePool _instance;
        public static BlueBottlePool Instance
        {
            get
            {
                if (_instance != null) return _instance;
            
                _instance = FindObjectOfType<BlueBottlePool>();

                if (_instance != null) return _instance;
            
                GameObject newGo = new GameObject();
                _instance = newGo.AddComponent<BlueBottlePool>();
                return _instance;
            }
        }

        protected void Awake()
        {
            _instance = this as BlueBottlePool;
        }
    }
}