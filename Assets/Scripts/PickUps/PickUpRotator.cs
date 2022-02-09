using Input;
using ScriptableObjects;
using Spawners;
using UnityEngine;

namespace PickUps
{
    public class PickUpRotator : MonoBehaviour
    {
        [SerializeField] private DragSettingsScriptableObject dragSettings;

        private Transform myTransform;
        private Transform cylinderTransform;

        private void OnPlayerDragged(Vector3 dragVector)
        {
            myTransform.RotateAround(cylinderTransform.position,Vector3.up, -dragVector.x * dragSettings.DragToAngleFactor);
        }
        
        private void OnCylinderSpawned(Transform cylinderTransform)
        {
            myTransform = transform;
            this.cylinderTransform = cylinderTransform;
        }
        
        private void Awake()
        {
            TouchController.OnPlayerDragged += OnPlayerDragged;
            PlatformGroupSpawner.OnCylinderSpawned += OnCylinderSpawned;
        }

        private void OnDestroy()
        {
            myTransform = null;
            cylinderTransform = null;
        
            TouchController.OnPlayerDragged -= OnPlayerDragged;
            PlatformGroupSpawner.OnCylinderSpawned -= OnCylinderSpawned;
        }
    }
}
