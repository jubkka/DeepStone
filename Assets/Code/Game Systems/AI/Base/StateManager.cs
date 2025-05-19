using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private State currentState;

    [Header("Components")]
    [SerializeField] private Enemy enemy;
    [SerializeField] private List<StateEntry> conditionStatesList;

    public static StateDict stateDict;
    public StateDict StateDict => stateDict;

    private void Awake()
    {
        stateDict = new StateDict(conditionStatesList);
    }

    private void Start()
    {
        enemy.Health.OnTakeDamage += TakeDamage;
        enemy.Vision.OnPlayerDetected += PlayerDetected;
        enemy.Memory.OnPlayerLost += PlayerLost;
    }

    private void Update() => RunStateMachine();

    private void RunStateMachine() 
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null && nextState != currentState) 
            SwitchToTheNextState(nextState);
    }

    private void SwitchToTheNextState(State nextState) 
    {
        currentState = nextState;
    }

    private void TakeDamage() => SwitchToTheNextState(stateDict.GetState(StateType.Search));

    private void PlayerDetected() => SwitchToTheNextState(stateDict.GetState(StateType.Chase));

    private void PlayerLost() => SwitchToTheNextState(stateDict.GetState(StateType.Idle));
}