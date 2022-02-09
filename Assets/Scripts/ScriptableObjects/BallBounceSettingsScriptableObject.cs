using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BallBounceSettings", menuName = "ScriptableObjects/BallBounceSettings", order = 1)]
    public class BallBounceSettingsScriptableObject : ScriptableObject
    {
        [SerializeField] private float jumpVelocity = 12f;
        [SerializeField] private float maxVelocityMagnitude = 20f;
        [SerializeField] private Vector3 ballScaleOnUnsafePlatformHit = new Vector3(0.5f,0.25f,0.5f);
        [SerializeField] private float ballScaleDurationOnUnsafePlatformHit = 0.1f;
    
        public float JumpVelocity => jumpVelocity;
        public float MaxVelocityMagnitude => maxVelocityMagnitude;
        public Vector3 BallScaleOnUnsafePlatformHit => ballScaleOnUnsafePlatformHit;
        public float BallScaleDurationOnUnsafePlatformHit => ballScaleDurationOnUnsafePlatformHit;
    }
}
