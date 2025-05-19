using System.Collections;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected State nextState;
    protected Coroutine coroutine;
    
    protected virtual void Start()
    {
        nextState = this;
    }

    public virtual State RunCurrentState()
    {
        if (coroutine == null)
            coroutine = StartCoroutine(ExecuteActions());

        return nextState;
    }

    protected virtual IEnumerator ExecuteActions() { yield return null; }

}