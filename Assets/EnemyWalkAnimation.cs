using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkAnimation : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    public void PlayWalkSound()
    {
        enemy.PlaySound(enemy.WalkSound);
    }
}
