using System.Collections;
using UnityEngine;

public class PatrolState : State
{
    [Header("Properties")]
    [SerializeField] private float walkPointRange = 5f;
    [SerializeField] private float nextStateDelay = 5f;

    [Header("Components")]
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private EnemyVision enemyVision;

    public override State RunCurrentState()
    {
        if (enemyVision.CanSeePlayer()) 
            return conditionStates[StateType.Chase];

        if (coroutine == null)
            coroutine = StartCoroutine(ExecuteActions());

        return nextState;
    }

    protected override IEnumerator ExecuteActions()
    {
        if(!enemyMove.IsDestinationReached())
            yield break;

        enemyMove.MoveToDestination(GetRandomWalkPoint());

        yield return new WaitForSeconds(nextStateDelay);
        
        SelectState();
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