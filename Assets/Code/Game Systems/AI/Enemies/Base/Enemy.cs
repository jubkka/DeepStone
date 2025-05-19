using UnityEngine;

public class Enemy : Damageable
{
    [Header("Components")]
    [SerializeField] private GameObject enemyObj;
    
    [Header("Properties")]
    [SerializeField] private EnemyHealth health;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private EnemyMemory memory;
    
    [Header("Actions")]
    [SerializeField] private EnemyVision vision;
    
    public EnemyHealth Health => health;
    public EnemyVision Vision => vision;
    public EnemyMemory Memory => memory;

    private void Start()
    {
        health.Init(enemyData.GetHealth);
    }

    public override void GetDamage(float damage)
    {
        health.TakeDamage(damage);
        
        if (health.CheckDeath())
            Destroy(enemyObj);
    }
}
