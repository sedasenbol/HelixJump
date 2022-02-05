using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "DragSettings", menuName = "ScriptableObjects/DragSettings", order = 1)]
    public class DragSettingsScriptableObject : ScriptableObject
    {
        [SerializeField] private float dragToAngleFactor = 1f;

        public float DragToAngleFactor => dragToAngleFactor;
    }
}