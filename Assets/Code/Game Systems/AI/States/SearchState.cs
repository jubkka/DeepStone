using System.Collections;
using UnityEngine;

public class SearchState : State
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private EnemyMemory enemyMemory;
    [SerializeField] private EnemyMove enemyMove;
    
    public override State RunCurrentState()
    {
        if (enemyMove.IsDestinationReached())
            enemyMove.MoveToDestination(enemy.Player.transform.position);

        return this;
    }

    protected override IEnumerator ExecuteActions()
    {
        yield return null;
    }
}