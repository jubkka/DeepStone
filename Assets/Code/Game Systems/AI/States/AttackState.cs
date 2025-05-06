using System;
using System.Collections;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private EnemyVision enemyVision;
    [SerializeField] private EnemyAttack enemyAttack;
    
    public override State RunCurrentState()
    {
        if (!enemyAttack.CanAttackPlayer()) 
            return conditionStates[StateType.Search];
        
        if (coroutine == null)
            coroutine = StartCoroutine(ExecuteActions());

        return this;
    }

    protected override IEnumerator ExecuteActions()
    {
        enemyAttack.Attack();
            
        yield return new WaitForSeconds(1f);
        
        coroutine = null;
    }
}