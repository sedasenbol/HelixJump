using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "ScriptableObjects/CameraSettings", order = 1)]
    public class CameraSettingsScriptableObject : ScriptableObject
    {
        [SerializeField] private Vector3 cameraStartPosition = new Vector3(0f,5f,-10f);
        
        public Vector3 CameraStartPosition => cameraStartPosition;
    }
}
