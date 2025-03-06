using UnityEngine;

public class AttackState : State
{
    public override State RunCurrentState()
    {
        Debug.Log("Attack State!");

        return this;
    }
}