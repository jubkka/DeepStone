using System.Collections;
using UnityEngine;

public class ChaseState : State
{
    private GameObject player;

    [Header("Components")]
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private EnemyVision enemyVision;

    protected override void Start()
    {
        base.Start();

        player = GameObject.FindWithTag("Player");
    }

    public override State RunCurrentState()
    {
        if (enemyVision.CanAttackPlayer()) 
            //return conditionStates[StateType.Attack];

        if (!enemyVision.CanSeePlayer()) 
            return conditionStates[StateType.Idle];

        if (coroutine == null)
            coroutine = StartCoroutine(ExecuteActions());
        
        return this;
    }

    protected override IEnumerator ExecuteActions()
    {
        enemyMove.MoveToDestination(player.transform.position);

        yield return new WaitForSeconds(0.25f);

        coroutine = null;
    }
}