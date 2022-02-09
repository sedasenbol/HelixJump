using System;
using System.Collections;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace Platforms
{
    public class PlatformGroupBreaker : MonoBehaviour
    {
        [SerializeField] private PlatformBreakSettingsScriptableObject platformBreakSettings;
        
        public void BreakMyPlatforms()
        {
            var childrenPlatformFlyers = GetComponentsInChildren<PlatformFlyer>();

            foreach (var platformFlyer in childrenPlatformFlyers)
            {
                platformFlyer.FlyAway();
            }

            GetComponent<PlatformGroupRotator>().enabled = false;

            StartCoroutine(SetInactiveWithDelay());
        }
        private IEnumerator SetInactiveWithDelay()
        {
            yield return new WaitForSeconds(platformBreakSettings.PlatformFlyingDuration);
            
            gameObject.SetActive(false);
        }

    }
}
