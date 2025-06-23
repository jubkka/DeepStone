using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [Header("Enemy")] 
    [SerializeField] private Enemy enemy;
    [Header("Destination")]
    [SerializeField] private Vector3 walkPoint;

    private void Start()
    {
        walkPoint = transform.position;
        enemy.Memory.OnPlayerLost += StopMoving;
    }

    public bool IsDestinationReached()
    {
        bool flag = !enemy.NavMeshAgent.pathPending 
                    && enemy.NavMeshAgent.remainingDistance <= enemy.NavMeshAgent.stoppingDistance
                    && enemy.NavMeshAgent.velocity.sqrMagnitude < 0.1f;
        
        if (flag)
        {
            enemy.Animator.Play("Idle");
            return true;
        }
        
        return false;
    }

    public void MoveToDestination(Vector3 newWalkPoint) 
    {
        enemy.Animator.Play("Walk");
        walkPoint = newWalkPoint;
        enemy.NavMeshAgent.SetDestination(walkPoint);
    }

    private void StopMoving()
    {
        enemy.Animator.Play("Idle");
        enemy.NavMeshAgent.ResetPath();
    }

    public bool IsMoving()
    {
        return enemy.NavMeshAgent.velocity.sqrMagnitude > 0.1f;
    }

    public bool CanReachPoint(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();
        enemy.NavMeshAgent.CalculatePath(destination, path);
        
        if (destination == enemy.NavMeshAgent.destination)
            return false;
        
        return path.status == NavMeshPathStatus.PathComplete;
    }
}
