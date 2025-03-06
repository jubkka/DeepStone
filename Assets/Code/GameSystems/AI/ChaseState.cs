public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange;

    public override State RunCurrentState()
    {
        if (isInAttackRange) 
        {
            return attackState;
        }
        
        return this;
    }
}