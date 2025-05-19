using System.Collections;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private EnemyAttack enemyAttack;
    
    public override State RunCurrentState()
    {
        if (!enemyAttack.CanAttackPlayer()) 
            return StateManager.stateDict.GetState(StateType.Chase);

        return base.RunCurrentState();
    }

    protected override IEnumerator ExecuteActions()
    {
        enemyAttack.Attack();
            
        yield return new WaitForSeconds(1f);
        
        coroutine = null;
    }
}