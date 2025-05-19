using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 walkPoint;
    
    [SerializeField] private EnemyMemory memory;

    private void Start()
    {
        walkPoint = transform.position;
        memory.OnPlayerLost += StopMoving;
    }

    public bool IsDestinationReached() 
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }

    public void MoveToDestination(Vector3 newWalkPoint) 
    {
        walkPoint = newWalkPoint;
        agent.SetDestination(walkPoint);
    }

    public void StopMoving()
    {
        walkPoint = transform.position;
        agent.SetDestination(walkPoint);
    }
}
