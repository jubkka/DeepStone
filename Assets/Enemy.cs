using System;
using UnityEngine;

public class Enemy : Damageable
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private EnemyIndicatorView view;
    [SerializeField] private SearchState searchState;

    private Health health;
    private int hp;

    private GameObject enemyObj;

    public event Action<State> OnTakeDamage;

    private void Start()
    {
        enemyObj = transform.parent.parent.gameObject;

        health = new Health(enemyData.GetHealth, enemyData.GetHealth, view);
    }

    public override void GetDamage(int damage)
    {
        health.Decrease(damage);
        view.ToggleIndicator(true);
        
        CheckDeath();
        
        OnTakeDamage?.Invoke(searchState);
    }

    private void CheckDeath()
    {
        if (health.Current <= 0)
            Destroy(enemyObj);
    }
}
