using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("Settings Vision")]
    [SerializeField] private float visionRange = 10f;
    [SerializeField] private float visionAngle = 45f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask obstaclesLayer;
    
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public bool CanSeePlayer() 
    {           
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer > visionRange) 
            return false;
        
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer > visionAngle)
            return false;

        if (Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstaclesLayer))
            return false;

        return true;
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
        Gizmos.color = Color.red;
        Vector3 rightLimit = Quaternion.Euler(0, visionAngle, 0) * transform.forward * visionRange;
        Vector3 leftLimit = Quaternion.Euler(0, -visionAngle, 0) * transform.forward * visionRange;

        Gizmos.DrawLine(transform.position, transform.position + rightLimit);
        Gizmos.DrawLine(transform.position, transform.position + leftLimit);

        Vector3 forwardLimit = transform.forward * attackRange;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + forwardLimit);
    }
}