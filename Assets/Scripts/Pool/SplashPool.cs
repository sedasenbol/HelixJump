using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;


namespace Pool
{
    public class SplashPool : Pool
    {
        private static SplashPool _instance;
        public static SplashPool Instance
        {
            get
            {
                if (_instance != null) return _instance;
            
                _instance = FindObjectOfType<SplashPool>();

                if (_instance != null) return _instance;
            
                GameObject newGo = new GameObject();
                _instance = newGo.AddComponent<SplashPool>();
                return _instance;
            }
        }

        protected void Awake()
        {
            _instance = this as SplashPool;
        }
    }
}