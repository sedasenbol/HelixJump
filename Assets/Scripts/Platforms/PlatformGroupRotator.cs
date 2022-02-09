using Input;
using ScriptableObjects;
using UnityEngine;

namespace Platforms
{
    public class PlatformGroupRotator : MonoBehaviour
    {
        [SerializeField] private DragSettingsScriptableObject dragSettings;

        private Transform myTransform;

        private void OnPlayerDragged(Vector3 dragVector)
        {
            myTransform.Rotate(Vector3.up, -dragVector.x * dragSettings.DragToAngleFactor);
        }
    
        private void OnEnable()
        {
            myTransform = transform;
        
            TouchController.OnPlayerDragged += OnPlayerDragged;
        }

        private void OnDisable()
        {
            myTransform = null;
        
            TouchController.OnPlayerDragged -= OnPlayerDragged;
        }
    }
}
