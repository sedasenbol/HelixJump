using System;
using Camera;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore
{
    public class GameManager : Singleton<GameManager>
    {
        private readonly GameInfo gameInfo = new GameInfo();

        private void Start()
        {
            gameInfo.CurrentScene = GameInfo.Scene.MainMenu;
            gameInfo.CurrentState = GameInfo.State.Start;
            
            LoadGameScene();
        }

        private void LoadGameScene()
        {
            SceneManager.LoadScene((int) GameInfo.Scene.Game, LoadSceneMode.Additive);
        }

        private void OnLevelFailed()
        {
            Time.timeScale = 0f;
            gameInfo.CurrentState = GameInfo.State.Over;
            UIManager.Instance.ShowFailScreen();
        }

        private void OnLevelCompleted()
        {
            gameInfo.CurrentState = GameInfo.State.Success;
            
            UIManager.Instance.ShowSuccessScreen();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene == SceneManager.GetSceneByBuildIndex(0)) {return;}

            SceneManager.SetActiveScene(scene);
            
            gameInfo.CurrentScene = GameInfo.Scene.Game;
            gameInfo.CurrentState = GameInfo.State.Play;
            
            LevelManager.Instance.HandleNewLevel();
        }
        
        private void PauseGame()
        {
            Time.timeScale = 0f;
            
            gameInfo.CurrentState = GameInfo.State.Paused;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;
            
            gameInfo.CurrentState = GameInfo.State.Play;
        }
        
        private void OnTapToContinueButtonClicked()
        {
            SceneManager.UnloadSceneAsync((int)gameInfo.CurrentScene);
            
            gameInfo.CurrentLevelIndex++;
            
            LoadGameScene();
        }
        
        private void OnEnable()
        {
            UIManager.OnPauseButtonClicked += PauseGame;
            UIManager.OnResumeButtonClicked += ResumeGame;
            UIManager.OnTapToContinueButtonClicked += OnTapToContinueButtonClicked;

            LevelManager.OnLevelFailed += OnLevelFailed;
            LevelManager.OnLevelCompleted += OnLevelCompleted;
            
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        private void OnDisable()
        {
            UIManager.OnPauseButtonClicked -= PauseGame;
            UIManager.OnResumeButtonClicked -= ResumeGame;
            UIManager.OnTapToContinueButtonClicked -= OnTapToContinueButtonClicked;
            
            LevelManager.OnLevelFailed -= OnLevelFailed;
            LevelManager.OnLevelCompleted -= OnLevelCompleted;
            
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public GameInfo GameInformation => gameInfo;
    }
}
