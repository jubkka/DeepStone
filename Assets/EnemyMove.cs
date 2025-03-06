using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float walkPointRange;
    [SerializeField] private Vector3 walkPoint;
    [SerializeField] private NavMeshAgent agent;

    private void RandomRange() 
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
    private void SetDestination() 
    {
        agent.SetDestination(walkPoint);
    }

    private bool IsDestionation() 
    {
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        Debug.Log(distanceToWalkPoint.magnitude);

        return distanceToWalkPoint.magnitude > 1f; 
    }

    public void MoveToDestination() 
    {
        RandomRange();
        
        //if (!IsDestionation()) return; 

        SetDestination();
    }
}
