using System;


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
            OnNewLevelLoaded?.Invoke();
        }

        // Called by Ball.cs when the ball hits an unsafe platform.
        public void HandleFailedLevel()
        {
            OnLevelFailed?.Invoke();
        }

        // Called by Ball.cs when the ball hits the last platform.
        public void HandleCompletedLevel()
        {
            OnLevelCompleted?.Invoke();
        }
    }
}
