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

        private bool isActive;

        private void FixedUpdate()
        {
            if (rb.velocity.sqrMagnitude < Mathf.Pow(ballBounceSettings.MaxVelocityMagnitude,2)) {return;}
            
            rb.AddForce(-Physics.gravity,ForceMode.Force);            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!isActive) {return;}
            
            var otherLayer = collision.gameObject.layer;
            
            if (otherLayer == unsafePlatformLayer)
            {
                LevelManager.Instance.HandleFailedLevel();

                isActive = false;
                rb.Sleep();
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

                isActive = false;
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

            isActive = true;
        }

        private void OnDisable()
        {
            myTransform = null;
        }
    }
}
