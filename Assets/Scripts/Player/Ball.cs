using System;
using GameCore;
using Pool;
using UnityEngine;

namespace Player
{
    public class Ball : MonoBehaviour
    {
        public static event Action OnBallsFirstHit; 

        [SerializeField] private BallBounceSettingsScriptableObject ballBounceSettings;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private MeshRenderer meshRenderer;
        
        private int safePlatformLayer;
        private int unsafePlatformLayer;
        private int lastPlatformLayer;

        private bool ballHitTheFirstPlatform;
        
        private Transform myTransform;
        private Vector3 splashSpawnRelativePos;

        private void OnCollisionEnter(Collision collision)
        {
            var otherLayer = collision.gameObject.layer;
            
            if (otherLayer == unsafePlatformLayer)
            {
                LevelManager.Instance.HandleFailedLevel();
            }
            else if (otherLayer == safePlatformLayer)
            {
                var splashSpawnPoint = myTransform.position + splashSpawnRelativePos;
                SpawnSplash(splashSpawnPoint, collision.gameObject.transform);
                BounceBall();
                
                if (ballHitTheFirstPlatform) {return;}
                
                OnBallsFirstHit?.Invoke();
                ballHitTheFirstPlatform = true;
            }
            else if (otherLayer == lastPlatformLayer)
            {
                LevelManager.Instance.HandleCompletedLevel();
            }
        }

        private void BounceBall()
        {
            rb.velocity = Vector3.up * ballBounceSettings.JumpVelocity;
        }

        private void SpawnSplash(Vector3 spawnPos, Transform platformTransform)
        {
            var splash = SplashPool.Instance.SpawnFromPool(spawnPos, Quaternion.identity);
            splash.parent = platformTransform;
        }
    
        private void OnEnable()
        {
            myTransform = transform;

            splashSpawnRelativePos = new Vector3(0f, -meshRenderer.bounds.extents.y, 0f);
        
            safePlatformLayer = LayerMask.NameToLayer("Platform/SafePlatform");
            unsafePlatformLayer = LayerMask.NameToLayer("Platform/UnsafePlatform");
            lastPlatformLayer = LayerMask.NameToLayer("Platform/LastPlatform");
        }

        private void OnDisable()
        {
            myTransform = null;
        }
    }
}
