using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectComponent : MonoBehaviour, ILoad
{
    [SerializeField] private GameObject effectViewPrefab;
    [SerializeField] private Transform effectViewsParent;
    private List<ActiveEffect> activeEffects;
    
    private DamageComponent damage;
    private IndicatorComponent indicator;
    
    public List<ActiveEffect> ActiveEffects => activeEffects;
    public DamageComponent Damage => damage;
    public IndicatorComponent Indicator => indicator;

    public void Init(IndicatorComponent indicatorComponent, DamageComponent damageComponent)
    {
        damage = damageComponent;
        indicator = indicatorComponent;
        activeEffects = new List<ActiveEffect>();
    }

    public void LoadFromOrigin(Origin origin)
    {
        
    }

    public void LoadFromSave() //Save TODO
    {
        
    }

    public void GetDefenceEffects()
    {
        /*foreach (var effect in itemEffectData)
        {
            if (effect is DefenceEffectData)
            {
                
            }
        } */  
    }
    
    public void Apply(IItemEffect effect)
    {
        effect.Apply(this);
    }

    public void RegisterTemporaryEffect(TemporaryEffect temporaryEffect, Action action)
    {
        if (IsExistingEffect(temporaryEffect))
            return;

        EffectView effectView = AddView(temporaryEffect);

        ActiveEffect activeEffect = new ActiveEffect(temporaryEffect, temporaryEffect.DurationEffect, action, effectView);
        activeEffects.Add(activeEffect);

        StartCoroutine(activeEffect.Run( (_) =>
            RemoveActiveEffect(activeEffect)
            ));
    }

    private bool IsExistingEffect(TemporaryEffect temporaryEffect)
    {
        ActiveEffect existingEffect = activeEffects.Find(x => x.Effect.Name == temporaryEffect.Name);

        if (existingEffect != null)
        {
            existingEffect.Refresh(temporaryEffect.DurationEffect);
            return true;
        }

        return false;
    }

    private void RemoveActiveEffect(ActiveEffect activeEffect)
    {
        activeEffects.Remove(activeEffect);
    }

    private EffectView AddView(TemporaryEffect temporaryEffect)
    {
        EffectView effectView = Instantiate(effectViewPrefab, effectViewsParent).GetComponentInChildren<EffectView>();
        effectView.Init(temporaryEffect.Icon, temporaryEffect.DurationEffect);

        return effectView;
    }
}
