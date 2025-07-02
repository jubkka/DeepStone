using UnityEngine;

public class EnemyAttackAnimation : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
        
    public void DamagePlayer()
    {
        enemy.Attack.Attack();
        enemy.PlaySound(enemy.AttackSound);
    }
}
