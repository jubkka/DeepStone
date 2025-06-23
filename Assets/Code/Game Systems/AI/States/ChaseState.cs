using System.Collections;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private Enemy enemy;
    
    private Transform playerTransform;
    private Transform enemyTransform;

    protected override void Start()
    {
        base.Start();
        
        playerTransform = enemy.Player.transform;
        enemyTransform = enemy.EnemyObj.transform;
    }

    public override State RunCurrentState()
    {
        if (enemy.Attack.InRangeAttack())
        {
            Vector3 directionToPlayer = playerTransform.position - enemyTransform.position;
            directionToPlayer.y = 0;

            float angle = Vector3.SignedAngle(enemyTransform.forward, directionToPlayer.normalized, Vector3.up);

            enemy.Rotate.StartRotate(angle, 0.25f);
        }

        if (enemy.Attack.CanAttackPlayer()) 
            return StateManager.stateDict.GetState(StateType.Attack);

        return base.RunCurrentState();
    }

    protected override IEnumerator ExecuteActions()
    {
        Vector3 direction = (playerTransform.position - enemyTransform.position).normalized;
        float stoppingDistance = 1f;

        Vector3 targetPosition = playerTransform.position - direction * stoppingDistance;

        enemy.Move.MoveToDestination(targetPosition);

        yield return new WaitForSeconds(0.15f);

        coroutine = null;
    }

}