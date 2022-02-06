using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "BallBounceSettings", menuName = "ScriptableObjects/BallBounceSettings", order = 1)]
public class BallBounceSettingsScriptableObject : ScriptableObject
{
    [SerializeField] private float jumpVelocity = 12f;
    [SerializeField] private float maxVelocityMagnitude = 20f;
    
    public float JumpVelocity => jumpVelocity;
    public float MaxVelocityMagnitude => maxVelocityMagnitude;
}
