using System.Collections;
using UnityEngine;

public class SearchState : State
{
    [SerializeField] private EnemyMemory enemyMemory;
    [SerializeField] private EnemyMove enemyMove;
    
    private GameObject player;

    protected override void Start()
    {
        base.Start();
        
        player = GameObject.FindWithTag("Player");
    }

    public override State RunCurrentState()
    {
        if (enemyMove.IsDestinationReached())
            enemyMove.MoveToDestination(player.transform.position);

        return this;
    }

    protected override IEnumerator ExecuteActions()
    {
        yield return null;
    }
}