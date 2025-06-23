using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    public void Attack()
    {
        if (enemy.DamageComponent != null)
        {
            enemy.DamageComponent.TakeDamageByEnemy(enemy.Data.GetDamage);
            enemy.PlaySound(enemy.AttackSound);
        }
    }
    
    public bool CanAttackPlayer() 
    {
        if (!InRangeAttack())
            return false;
        
        return Physics.Raycast(transform.position, transform.forward, enemy.Data.GetDamageRange, enemy.PlayerMask);
    }

    public bool InRangeAttack()
    {
        float distanceToPlayer = Vector3.Distance(enemy.Player.transform.position, transform.position);
        
        if (distanceToPlayer > enemy.Data.GetDamageRange)
            return false;

        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 forwardLimit = transform.forward * enemy.Data.GetDamageRange;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + forwardLimit);
    }
}