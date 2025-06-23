using System;
using System.Collections;
using UnityEngine;

public class ActiveEffect 
{
    private readonly TemporaryEffect effect;
    private readonly Action action;
    private readonly EffectView effectView;
    private float endTime;
    
    public TemporaryEffect Effect => effect;

    public ActiveEffect(TemporaryEffect effect, float duration, Action action, EffectView effectView = null)
    {
        this.effect = effect;
        this.action = action;
        this.effectView = effectView;
        endTime = Time.time + duration;
    }

    public void Refresh(float newDuration)
    {
        float newEndTime = Time.time + newDuration;

        if (newEndTime > endTime)
            endTime = newEndTime;

        effectView?.RefreshDuration(endTime - Time.time);
    }

    public IEnumerator Run(Action<ActiveEffect> onComplete)
    {
        while (Time.time < endTime)
        {
            action.Invoke();
            yield return new WaitForSeconds(1f);
        }
        
        onComplete?.Invoke(this);
    }
}