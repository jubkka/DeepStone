using UnityEngine;

public abstract class StateDecision : State
{
    [Header("Transition to States")]
    [SerializeField] protected StateChances[] chancesStates;
    
    [Header("Properties")]
    [SerializeField] protected float nextStateDelay;
    
    [SerializeField] [Range(0f, 30f)] protected float minNextStateDelay;
    [SerializeField] [Range(0f, 30f)] protected float maxNextStateDelay;

    protected override void Start()
    {
        nextStateDelay = Random.Range(minNextStateDelay, maxNextStateDelay);
    }

    protected void SelectRandomState() 
    {
        float roll = Random.value;
        float cumulativeChange = 0f;

        foreach(var state in chancesStates) 
        {
            cumulativeChange += state.chance;

            if (roll < cumulativeChange) 
            {
                nextState = state.state;
                break;
            }
        }
    }
}