using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [Header("Transition to States")]
    [SerializeField] protected StateChances[] chancesStates;
    [SerializeField] protected List<StateEntry> conditionStatesList = new List<StateEntry>();
    protected Dictionary<StateType, State> conditionStates;
    protected State nextState;
    protected Coroutine coroutine;
    public abstract State RunCurrentState();
    protected abstract IEnumerator ExecuteActions();

    protected virtual void Start()
    {
        nextState = this;

        conditionStates = new Dictionary<StateType, State>();

        foreach (var entry in conditionStatesList) 
            conditionStates.Add(entry.type, entry.state);
    }
    protected void SelectState() 
    {
        float roll = Random.value;
        float cumulativeChange = 0f;

        foreach(var state in chancesStates) 
        {
            cumulativeChange += state.chance;

            if (roll < cumulativeChange) 
            {
                nextState = state.state;
                coroutine = null;
                return;
            }
        }

        nextState = this;
        coroutine = null;
    }
}