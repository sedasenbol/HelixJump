using Pool;
using ScriptableObjects;
using UnityEngine;

namespace Spawners
{
    public class PickUpSpawner : MonoBehaviour
    {
        [SerializeField] private GreenBottleSettingsScriptableObject greenBottleSettings;
        [SerializeField] private Transform ballTransform;
        
        public void ReceivePotentialSpawnPlace(Transform platformGroup)
        {
            var shouldSpawnGreenBottle = Random.Range(0f, 1f) < greenBottleSettings.SpawnProbabilityOnPlatform;

            if (!shouldSpawnGreenBottle) {return;}
            
            SpawnGreenBottle(platformGroup, GetSpawnPosition(platformGroup));
        }

        private Vector3 GetSpawnPosition(Transform platformGroup)
        {
            var ballPosition = ballTransform.position;
            
            var firstSpawnPosition = new Vector3()
            {
                x = ballPosition.x,
                y = platformGroup.position.y + greenBottleSettings.HeightOnPlatformGroup,
                z = ballPosition.z
            };

            return firstSpawnPosition;
        }

        private void SpawnGreenBottle(Transform platformGroupTransform, Vector3 firstSpawnPosition)
        {
            var greenBottle = GreenBottlePool.Instance.SpawnFromPool(firstSpawnPosition, Quaternion.identity);

            greenBottle.RotateAround(platformGroupTransform.position, Vector3.up, Random.Range(0f,360f));
        } 
    }
}