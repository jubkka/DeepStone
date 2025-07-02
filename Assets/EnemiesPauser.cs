using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesPauser : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    
    private static EnemiesPauser instance;
    public static EnemiesPauser Instance => instance;
    private void Awake() => instance = this;

    private void Start()
    {
        enemies = gameObject.GetComponentsInChildren<Enemy>().ToList();
    }
    
    public void ChangeStateEnemies(bool state)
    {
        if (state)
            EnemiesFreeze();
        else
            EnemiesUnfreeze();
    }

    private void EnemiesFreeze()
    {
        foreach (var enemy in enemies)
            enemy.Freeze();
    }

    private void EnemiesUnfreeze()
    {
        foreach (var enemy in enemies)
            enemy.UnFreeze();
    }
}
