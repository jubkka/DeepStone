using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private State currentState;
    [SerializeField] private Enemy enemy;

    private void Start()
    {
        enemy.OnTakeDamage += SwitchToTheNextState;
    }

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine() 
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null) 
        {
            SwitchToTheNextState(nextState);
        } 
    }

    public void SwitchToTheNextState(State nextState) 
    {
        currentState = nextState;
    }
}