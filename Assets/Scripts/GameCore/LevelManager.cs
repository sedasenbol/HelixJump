using System;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCore
{
    public class LevelManager : Singleton<LevelManager>
    {
        public void HandleFailedLevel()
        {
            GameManager.Instance.HandleFailedLevel();
        }

        public void HandleCompletedLevel()
        {
            GameManager.Instance.HandleCompletedLevel();
        }
    }
}
