using System;
using UnityEngine;

[Serializable]
public class EnemySpawn
{
    public EnemyData data;
    [Range(0,1000)] public float weight;
}