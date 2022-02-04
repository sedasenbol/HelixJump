using System;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCore
{
    public class LevelManager : MonoBehaviour
    {
        public static event Action OnLevelStarted;
        public static event Action OnLevelCompleted;
        public static event Action OnLevelFailed;

        #region Singleton

        private static LevelManager instance;

        public static LevelManager Instance => instance;


        private void Awake()
        {
            if (instance != null && instance != this) { Destroy(this.gameObject); return; } 
        
            instance = this;
        }

        #endregion
    
        
    }
}
