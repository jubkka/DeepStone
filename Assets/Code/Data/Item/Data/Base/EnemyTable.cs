using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemies Table", menuName = "Table/New Enemy Table")]
public class EnemyTable : ScriptableObject
{
    public List<EnemySpawn> enemies;
}