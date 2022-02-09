using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlatformBreakSettings", menuName = "ScriptableObjects/PlatformBreakSettings", order = 1)]
    public class PlatformBreakSettingsScriptableObject : ScriptableObject
    {
        [SerializeField] private float platformFlyingDistance = 10f;
        [SerializeField] private float platformFlyingDuration = 1f;

        public float PlatformFlyingDistance => platformFlyingDistance;
        public float PlatformFlyingDuration => platformFlyingDuration;
    }
}