using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BlueBottleSettings", menuName = "ScriptableObjects/BlueBottleSettings", order = 1)]
    public class BlueBottleSettingsScriptableObject : ScriptableObject
    {
        [SerializeField] private float spawnProbabilityOnPlatform = 0.05f;
        [SerializeField] private float heightOnPlatformGroup = 2f;

        public float SpawnProbabilityOnPlatform => spawnProbabilityOnPlatform;
        public float HeightOnPlatformGroup => heightOnPlatformGroup;
    }
}