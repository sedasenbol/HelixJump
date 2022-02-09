using System;
using System.Collections;
using System.Collections.Generic;
using PickUps;
using ScriptableObjects;
using UnityEngine;

namespace Platforms
{
    public class UnsafePlatform : MonoBehaviour
    {
        [SerializeField] private BlueBottleSettingsScriptableObject blueBottleSettings;
        
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private MeshCollider meshCollider;
        
        private void OnBlueBottlePickedUp()
        {
            meshRenderer.enabled = false;
            meshCollider.enabled = false;

            StartCoroutine(EnableUnsafePlatformWithDelay());
        }

        private IEnumerator EnableUnsafePlatformWithDelay()
        {
            yield return new WaitForSeconds(blueBottleSettings.DisabledPlatformDuration);

            meshRenderer.enabled = true;
            meshCollider.enabled = true;
        }

        private void OnEnable()
        {
            BlueBottle.OnBlueBottlePickedUp += OnBlueBottlePickedUp;
        }

        private void OnDisable()
        {
            BlueBottle.OnBlueBottlePickedUp -= OnBlueBottlePickedUp;
        }
    }
}
