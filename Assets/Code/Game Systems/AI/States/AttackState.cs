using System.Collections;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private StateManager stateManager;
    [SerializeField] private Enemy enemy;
    
    public override State RunCurrentState()
    {
        if (!enemy.Attack.CanAttackPlayer()) 
            return stateManager.stateDict.GetState(StateType.Chase);

        return base.RunCurrentState();
    }

    protected override IEnumerator ExecuteActions()
    {
        enemy.Animator.Play("Attack");
        
        yield return new WaitForSeconds(1f);
        
        coroutine = null;
    }
}