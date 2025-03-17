using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 walkPoint;

    private void Start()
    {
        walkPoint = transform.position;   
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
}
