using GameCore;
using Pool;
using UnityEngine;

namespace Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private BallBounceSettingsScriptableObject ballBounceSettings;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private MeshRenderer meshRenderer;
        
        private int safePlatformLayer;
        private int unsafePlatformLayer;
        
        private Transform myTransform;
        private Vector3 splashSpawnRelativePos;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == unsafePlatformLayer)
            {
                LevelManager.Instance.HandleFailedLevel();
            }
            else if (collision.gameObject.layer == safePlatformLayer)
            {
                var splashSpawnPoint = myTransform.position + splashSpawnRelativePos;
                SpawnSplash(splashSpawnPoint, collision.gameObject.transform);
                BounceBall();
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
        }

        private void OnDisable()
        {
            myTransform = null;
        }
    }
}
