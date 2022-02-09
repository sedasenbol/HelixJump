using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Pool
{
    public class GreenBottlePool : Pool
    {
        private static GreenBottlePool _instance;
        public static GreenBottlePool Instance
        {
            get
            {
                if (_instance != null) return _instance;
            
                _instance = FindObjectOfType<GreenBottlePool>();

                if (_instance != null) return _instance;
            
                GameObject newGo = new GameObject();
                _instance = newGo.AddComponent<GreenBottlePool>();
                return _instance;
            }
        }

        protected void Awake()
        {
            _instance = this as GreenBottlePool;
        }
        
    }
}