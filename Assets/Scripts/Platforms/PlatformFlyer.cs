using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Pool;
using ScriptableObjects;
using UnityEngine;

namespace Platforms
{
    public class PlatformFlyer : MonoBehaviour
    {
        [SerializeField] private PlatformBreakSettingsScriptableObject platformBreakSettings;
        
        private Transform myTransform;
        
        public void FlyAway()
        {
            myTransform.GetComponentInChildren<Collider>().enabled = false;
            
            myTransform.DOMove(myTransform.position - myTransform.right * platformBreakSettings.PlatformFlyingDistance,
                platformBreakSettings.PlatformFlyingDuration);

            StartCoroutine(SetInactiveWithDelay());
        }

        private IEnumerator SetInactiveWithDelay()
        {
            yield return new WaitForSeconds(platformBreakSettings.PlatformFlyingDuration);
            
            gameObject.SetActive(false);
        }
        
        private void OnEnable()
        {
            myTransform = transform;
        }

        private void OnDisable()
        {
            myTransform = null;
        }
    }
}