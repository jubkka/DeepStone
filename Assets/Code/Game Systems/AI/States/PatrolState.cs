using System.Collections;
using UnityEngine;

public class PatrolState : StateDecision
{
    [Header("Properties")]
    [SerializeField] private float walkPointRange = 5f;

    [Header("Components")]
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private EnemyVision enemyVision;
    
    protected override IEnumerator ExecuteActions()
    {
        if(!enemyMove.IsDestinationReached())
            yield break;

        enemyMove.MoveToDestination(GetRandomWalkPoint());

        yield return new WaitForSeconds(nextStateDelay);
        
        SelectRandomState();
        
        coroutine = null;
    }

    private Vector3 GetRandomWalkPoint() 
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        return new Vector3(
            transform.position.x + randomX, 
            transform.position.y, 
            transform.position.z + randomZ
        );
    }
}