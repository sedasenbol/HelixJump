using System;
using DG.Tweening;
using Pool;


namespace GameCore
{
    public class LevelManager : Singleton<LevelManager>
    {
        public static event Action OnNewLevelLoaded;
        public static event Action OnLevelFailed;
        public static event Action OnLevelCompleted; 
        
        // Called by GameManager.cs when "Game" scene is loaded. 
        public void HandleNewLevel()
        {
            SplashPool.Instance.InitializeItemPoolDict();
            GreenBottlePool.Instance.InitializeItemPoolDict();
            BlueBottlePool.Instance.InitializeItemPoolDict();
            
            OnNewLevelLoaded?.Invoke();
        }

        // Called by Ball.cs when the ball hits an unsafe platform.
        public void HandleFailedLevel()
        {
            DOTween.CompleteAll();
            OnLevelFailed?.Invoke();
        }

        // Called by Ball.cs when the ball hits the last platform.
        public void HandleCompletedLevel()
        {
            DOTween.CompleteAll();
            OnLevelCompleted?.Invoke();
        }
    }
}
