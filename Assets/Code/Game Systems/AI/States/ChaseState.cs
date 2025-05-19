using System.Collections;
using UnityEngine;

public class ChaseState : State
{
    private GameObject player;

    [Header("Components")]
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private EnemyAttack enemyAttack;

    protected override void Start()
    {
        base.Start();

        player = GameObject.FindWithTag("Player");
    }

    public override State RunCurrentState()
    {
        if (enemyAttack.CanAttackPlayer()) 
            return StateManager.stateDict.GetState(StateType.Attack);

        return base.RunCurrentState();
    }

    protected override IEnumerator ExecuteActions()
    {
        enemyMove.MoveToDestination(player.transform.position);

        yield return new WaitForSeconds(0.15f);

        coroutine = null;
    }
}