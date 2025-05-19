using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("Settings Vision")]
    [SerializeField] private float visionRange = 10f;
    [SerializeField] private float visionAngle = 45f;
    [SerializeField] private LayerMask obstaclesLayer;
    
    private GameObject player;
    private bool wasVisible = false;
    private bool canSee = false;
    public event Action OnPlayerDetected;
    public event Action OnPlayerLost;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        canSee = CanSeePlayer();
        
        if (canSee && !wasVisible)
        {
            OnPlayerDetected?.Invoke();
            
            Debug.Log("Player Detected");
        }
        else if (!canSee && wasVisible)
        {
            OnPlayerLost?.Invoke();
            
            Debug.Log("Player lost");
        }
        
        wasVisible = canSee;
    }

    private bool CanSeePlayer()
    {
        if (!PlayerExists())
            return false;
        
        if (!IsPlayerInRange(out float distanceToPlayer))
            return false;
        
        if (!IsPlayerInAngle(out Vector3 directionToPlayer))
            return false;

        if (!CanRayReachPlayer(distanceToPlayer, directionToPlayer))
            return false;
            
        return true;
    }

    private bool PlayerExists()
    {
        if (player == null) 
            return false;
        
        return true;
    }

    private bool IsPlayerInRange(out float distanceToPlayer)
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer > visionRange) 
            return false;
        
        return true;
    }

    private bool IsPlayerInAngle(out Vector3 directionToPlayer)
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer > visionAngle)
            return false;

        return true;
    }

    private bool CanRayReachPlayer(float distanceToPlayer, Vector3 directionToPlayer)
    {
        if (Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstaclesLayer))
            return false;

        return true;
    }

    private void OnDrawGizmosSelected()
    {
        OnDrawAngleGizmos();
        OnDrawRangeGizmos();
    }

    private void OnDrawRangeGizmos()
    {
        Gizmos.color = Color.red;
    }

    private void OnDrawAngleGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rightLimit = Quaternion.Euler(0, visionAngle, 0) * transform.forward * visionRange;
        Vector3 leftLimit = Quaternion.Euler(0, -visionAngle, 0) * transform.forward * visionRange;

        Gizmos.DrawLine(transform.position, transform.position + rightLimit);
        Gizmos.DrawLine(transform.position, transform.position + leftLimit);
    }
}