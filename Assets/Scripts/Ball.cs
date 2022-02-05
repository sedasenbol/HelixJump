using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using GameCore;
using Pool;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private BallBounceSettingsScriptableObject ballBounceSettings;
    [SerializeField] private Rigidbody rb;
    
    private int safePlatformLayer;
    private int unsafePlatformLayer;

    private Vector3 splashSpawnRelativePos;

    private Transform myTransform;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == unsafePlatformLayer)
        {
            LevelManager.Instance.HandleFailedLevel();
        }
        else if (collision.gameObject.layer == safePlatformLayer)
        {
            SpawnSplash(collision.GetContact(0).point);
            BounceBall();
        }
    }

    private void BounceBall()
    {
        rb.velocity = Vector3.up * ballBounceSettings.JumpVelocity;
    }

    private void SpawnSplash(Vector3 spawnPos)
    {
        SplashPool.Instance.SpawnFromPool(spawnPos, Quaternion.identity);
    }
    
    private void OnEnable()
    {
        myTransform = transform;
        
        safePlatformLayer = LayerMask.NameToLayer("SafePlatform");
        unsafePlatformLayer = LayerMask.NameToLayer("UnsafePlatform");
    }

    private void OnDisable()
    {
        myTransform = null;
    }
}
