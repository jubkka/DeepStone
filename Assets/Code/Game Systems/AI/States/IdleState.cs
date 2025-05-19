using System.Collections;
using UnityEngine;

public class IdleState : StateDecision
{
    protected override IEnumerator ExecuteActions() 
    {
        yield return new WaitForSeconds(nextStateDelay);
        
        SelectRandomState();
        
        coroutine = null;
    }
}