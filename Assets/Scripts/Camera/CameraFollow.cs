using System;
using GameCore;
using Player;
using ScriptableObjects;
using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private CameraSettingsScriptableObject cameraSettings;

        private Transform myTransform;
        private Transform ballTransform;
        private Vector3 offset;

        private bool shouldFollowPlayer;
        
        private void OnNewLevelLoaded()
        {
            myTransform.position = cameraSettings.CameraStartPosition;
            ballTransform = FindObjectOfType<Ball>().transform;
        }

        private void OnBallsFirstHit()
        {
            shouldFollowPlayer = true;
            
            offset = myTransform.position - ballTransform.position;
        }

        private void OnLevelEnd()
        {
            shouldFollowPlayer = false;
        }

        private void LateUpdate()
        {
            if (!shouldFollowPlayer) {return;}

            var targetPosition = ballTransform.position + offset;
            var myPosition = myTransform.position;
            
            if (targetPosition.y > myPosition.y) {return;}

            myTransform.position = targetPosition;
        }

        private void OnEnable()
        {
            myTransform = transform;
            
            LevelManager.OnNewLevelLoaded += OnNewLevelLoaded;
            LevelManager.OnLevelFailed += OnLevelEnd;
            LevelManager.OnLevelCompleted += OnLevelEnd;

            Ball.OnBallsFirstHit += OnBallsFirstHit;
        }

        private void OnDisable()
        {
            myTransform = null;
            
            LevelManager.OnNewLevelLoaded -= OnNewLevelLoaded;
            LevelManager.OnLevelFailed -= OnLevelEnd;
            LevelManager.OnLevelCompleted -= OnLevelEnd;
            
            Ball.OnBallsFirstHit -= OnBallsFirstHit;
        }
    }
}
