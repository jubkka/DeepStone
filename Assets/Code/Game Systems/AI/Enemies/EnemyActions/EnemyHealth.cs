using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Health health;
    
    [SerializeField] private EnemyIndicatorView view;
    public event Action OnTakeDamage;

    public void Init(int hp)
    {
        health = new Health(hp, hp,view);
    }

    public void TakeDamage(float damage)
    {
        health.Decrease(damage);
        view.ToggleIndicator(true);
        
        OnTakeDamage?.Invoke();
    }

    public bool CheckDeath()
    {
        return health.Current <= 0;
    }
}