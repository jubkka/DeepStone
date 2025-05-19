using System.Collections.Generic;

public class StateDict
{
    private Dictionary<StateType, State> conditionStates;

    public StateDict(List<StateEntry> conditionStatesList)
    {
        Init(conditionStatesList);
    }
    
    private void Init(List<StateEntry> conditionStatesList)
    {
        conditionStates = new Dictionary<StateType, State>();

        foreach (var entry in conditionStatesList) 
            conditionStates.Add(entry.type, entry.state);
    }
    
    public State GetState(StateType state) => conditionStates[state];
}