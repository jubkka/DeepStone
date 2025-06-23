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
        enemyMove.MoveToDestination(GetRandomWalkPoint());

        yield return new WaitUntil(() => enemyMove.IsMoving());
        yield return new WaitUntil(() => enemyMove.IsDestinationReached());
        yield return new WaitForSeconds(nextStateDelay);

        SelectRandomState();

        coroutine = null;
    }

    private Vector3 GetRandomWalkPoint() 
    {
        Vector3 candidatePoint;
        int attempts = 30;

        do
        {
            float radius = Random.Range(3f, 5f);
            float angle = Random.Range(0f, 360f);
            
            float offsetX = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float offsetZ = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

            candidatePoint = new Vector3(
                transform.position.x + offsetX,
                0f,
                transform.position.z + offsetZ
            );

            attempts--;

        } while (!enemyMove.CanReachPoint(candidatePoint) && attempts > 0);

        return candidatePoint;
    }
}