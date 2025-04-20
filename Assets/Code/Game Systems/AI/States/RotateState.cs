using System.Collections;
using UnityEngine;

public class RotateState : State
{   
    [Header("Properities")]
    [SerializeField] private float nextStateDelay = 5f;
    [SerializeField] private float angleMaxRotate = 90f;
    [SerializeField] private float angleMinRotate = 75f;
    [SerializeField] private float durationRotate = 0.75f; 
    
    [Header("Components")]
    [SerializeField] private EnemyRotate enemyRotate;
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
        enemyRotate.StartRotate(RandomAngle(), durationRotate);

        yield return new WaitForSeconds(nextStateDelay);

        SelectRandomState();
    }

    private float RandomAngle() 
    {
        float angle = Random.Range(angleMinRotate, angleMaxRotate);
        float sign = Random.Range(0, 2) * 2 - 1;

        return angle * sign;
    }
}