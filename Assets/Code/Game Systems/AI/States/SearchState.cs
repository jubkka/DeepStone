using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    [SerializeField] private EnemyVision enemyVision;
    [SerializeField] private EnemyMove enemyMove;
    
    [SerializeField] private float forgetPlayerTimer = 5f;
    
    private float forgetPlayerTime;
    private GameObject player;

    private void Start()
    {
        base.Start();
        
        player = GameObject.FindWithTag("Player");
    }

    public override State RunCurrentState()
    {
        if (enemyVision.CanSeePlayer())
        {
            forgetPlayerTime = 0f;
            return conditionStates[StateType.Chase];
        }
            
        forgetPlayerTime += Time.deltaTime;

        if (forgetPlayerTime >= forgetPlayerTimer)
        {
            forgetPlayerTime = 0f;
            return conditionStates[StateType.Idle];
        }
        
        if (enemyMove.IsDestinationReached())
            enemyMove.MoveToDestination(player.transform.position);

        return this;
    }

    protected override IEnumerator ExecuteActions()
    {
        yield return null;
    }
}