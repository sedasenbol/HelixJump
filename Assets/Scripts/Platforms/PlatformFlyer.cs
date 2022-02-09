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

            myTransform.DOMove(myTransform.position - myTransform.right * platformBreakSettings.PlatformFlyingXDistance -
                myTransform.up * platformBreakSettings.PlatformFlyingYDistance, platformBreakSettings.PlatformFlyingDuration).OnComplete(
                () =>
                {
                    gameObject.SetActive(false);
                });

            myTransform.DOScale(Vector3.zero, platformBreakSettings.PlatformFlyingDuration);
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