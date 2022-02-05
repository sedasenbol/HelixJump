using System;
using Camera;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore
{
public class GameManager : Singleton<GameManager>
{
    public static event Action OnNextLevelTriggered;
    
    private readonly GameState gameState = new GameState();

    private void Start()
    {
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene((int) GameState.Scene.Game, LoadSceneMode.Additive);
        
        gameState.CurrentScene = GameState.Scene.Game;
        gameState.CurrentState = GameState.State.Play;
    }

    public void HandleFailedLevel()
    {
        Time.timeScale = 0f;
        gameState.CurrentState = GameState.State.Over;
        UIManager.Instance.ShowFailScreen();
    }

    public void HandleCompletedLevel()
    {
        OnNextLevelTriggered?.Invoke();
    }

    private void TriggerNextLevel()
    {
        //DOTween.KillAll();
        
        //mainCamTransform.position = cameraFollow.StartPosition;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene == SceneManager.GetSceneByBuildIndex(0)) {return;}

        SceneManager.SetActiveScene(scene);
        OnNextLevelTriggered?.Invoke();
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;
        gameState.CurrentState = GameState.State.Paused;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        gameState.CurrentState = GameState.State.Play;
    }
    
    private void OnEnable()
    {
        UIManager.OnPauseButtonClicked += PauseGame;
        UIManager.OnResumeButtonClicked += ResumeGame;

        //LevelManager.OnLevelCompleted += OnLevelCompleted;
        //LevelManager.OnLevelFailed += OnLevelFailed;
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDisable()
    {
        UIManager.OnPauseButtonClicked -= PauseGame;
        UIManager.OnResumeButtonClicked -= ResumeGame;
        
        //LevelManager.OnLevelCompleted -= OnLevelCompleted;
        //LevelManager.OnLevelFailed -= OnLevelFailed;
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
}
