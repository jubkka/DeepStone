using System.Collections;
using UnityEngine;

public class PatrollingState : State
{
    public IdleState idleState;
    public ChaseState chaseState;
    public EnemyMove enemyMove;
    private Coroutine patrollingCoroutine;
    [SerializeField] private bool isPatrolling = false;

    public override State RunCurrentState()
    {
        if (!isPatrolling)
        {
            return idleState;
        }

        if (patrollingCoroutine == null)
        {
            patrollingCoroutine = StartCoroutine(Patrolling());
        }

        return this;
    }

    private IEnumerator Patrolling()
    {
        isPatrolling = true;

        while (isPatrolling)
        {
            enemyMove.MoveToDestination();
            yield return new WaitForSeconds(5);

            if (Random.Range(0, 100) < 10)
            {
                isPatrolling = false;
                patrollingCoroutine = null;
                yield break;
            }
        }
    }
}