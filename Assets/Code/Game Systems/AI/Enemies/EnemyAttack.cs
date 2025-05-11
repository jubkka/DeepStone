using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private IndicatorComponent indicator;
    
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask playerMask;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        indicator = CharacterStatsSystems.Instance.GetIndicator;
    }

    public void Attack()
    {
        indicator.Damage(1);
    }
    
    public bool CanAttackPlayer() 
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer > attackRange)
            return false;
        
        return Physics.Raycast(transform.position, transform.forward, attackRange, playerMask);
    } 
    
    private void OnDrawGizmosSelected()
    {
        Vector3 forwardLimit = transform.forward * attackRange;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + forwardLimit);
    }
}