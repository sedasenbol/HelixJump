using System;
using DG.Tweening;
using UnityEngine;

namespace Platforms
{
    public class DisappearingPlatform : MonoBehaviour
    {
        private int ballLayer;

        private void OnEnable()
        {
            ballLayer = LayerMask.NameToLayer("Ball");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer != ballLayer) {return;}
            
            transform.DOScale(Vector3.zero, 1f);
        }
    }
}