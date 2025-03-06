using UnityEngine;

public class IdleState : State
{
    public PatrollingState patrollingState;
    public ChaseState chaseState;
    public bool canSeeThePlayer; 

    public override State RunCurrentState()
    {
        return DecideToPatrol();
    }

    private State DecideToPatrol() 
    {
        if (Random.Range(0, 100) == 1) return patrollingState;

        return this;
    }
}