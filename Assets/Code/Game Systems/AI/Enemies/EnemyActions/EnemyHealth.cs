using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public event Action OnTakeDamage;

    public void TakeDamage(float damage)
    {
        enemy.HP.Decrease(damage);
        enemy.IndicatorView.ToggleIndicator(true);
        enemy.PlaySound(enemy.DamageSound);
        
        OnTakeDamage?.Invoke();
    }

    public bool CheckDeath()
    {
        return enemy.HP.Current <= 0;
    }
}