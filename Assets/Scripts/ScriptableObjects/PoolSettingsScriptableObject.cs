using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolSettings", menuName = "ScriptableObjects/PoolSettings", order = 1)]
public class PoolSettingsScriptableObject : ScriptableObject
{
    [SerializeField] private int poolSize;

    public int PoolSize => poolSize;
}
