using System;
using UnityEngine;

[Serializable]
public struct StateChances
{
    public State state;
    [Range(0f, 1f)] public float chance;
}


[Serializable]
public struct StateEntry
{
    public StateType type;
    public State state;
}

public enum StateType 
{
    Attack,
    Chase,
    Patrol,
    Rotate,
    Idle
}

