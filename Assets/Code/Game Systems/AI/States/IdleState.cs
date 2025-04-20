using System.Collections;
using UnityEngine;

public class IdleState : State
{
    [Header("Components")]
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
        yield return new WaitForSeconds(1f);

        SelectRandomState();
    }
}