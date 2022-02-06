using System;
using System.Collections.Generic;
using GameCore;
using Platforms;
using UnityEngine;

namespace Player
{
    public class BallProgressTracker : Singleton<BallProgressTracker>
    {
        private bool isGameActive;
        private Transform ballTransform;
        private List<Transform> platformGroupTransforms;

        private int currentPlatformIndex;
        
        public void Initialize(List<Transform> platformGroupTransforms)
        {
            this.platformGroupTransforms = platformGroupTransforms;
            
            isGameActive = true;
            
            ballTransform = FindObjectOfType<Ball>().transform;
        }

        private void OnLevelEnd()
        {
            isGameActive = false;

            platformGroupTransforms = null; 
            ballTransform = null;
        }

        private void Update()
        {
            if (!isGameActive) {return;}

            var currentPlatformGroup = platformGroupTransforms[currentPlatformIndex];

            if (ballTransform.position.y > currentPlatformGroup.position.y) {return;}

            currentPlatformGroup.GetComponent<PlatformGroupBreaker>().BreakMyPlatforms();
            currentPlatformIndex++;
            Debug.Log(currentPlatformIndex);
        }

        private void OnEnable()
        {
            LevelManager.OnLevelFailed += OnLevelEnd;
            LevelManager.OnLevelCompleted += OnLevelEnd;
        }

        private void OnDisable()
        {
            LevelManager.OnLevelFailed -= OnLevelEnd;
            LevelManager.OnLevelCompleted -= OnLevelEnd;
        }
    }
}
