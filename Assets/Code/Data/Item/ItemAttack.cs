using System;
using UnityEngine;

public abstract class ItemAttack : MonoBehaviour
{
    [SerializeField] protected AttributeType attributeTypeImpactDamage;
    [SerializeField] protected GenericContainer container; 
    
    protected Camera cam;
    protected GenericElementData data;
    
    protected AttributeComponent attributeComponent;
    protected EffectComponent effectComponent;
    protected AttackView attackView;

    private Action<int> OnAttributeChanged;
    private void OnDestroy()
    {
        if (attributeComponent != null)
            attributeComponent.GetAttribute(attributeTypeImpactDamage).OnAttributeChanged -= OnAttributeChanged;
        if (attackView != null)
            OnAttributeChanged -= attackView.UpdateText;
    }

    public void Init(AttributeComponent attribute, EffectComponent effect, AttackView view)
    {
        cam = Camera.main;
        Data = container.Data;
        attributeComponent = attribute;
        effectComponent = effect;
        attackView = view;
        
        OnAttributeChanged += _ => CalculateDamage();
        OnAttributeChanged += attackView.UpdateText;
        attributeComponent.GetAttribute(attributeTypeImpactDamage).OnAttributeChanged += OnAttributeChanged;
        
        CalculateDamage();
    }
    
    protected abstract GenericElementData Data { set; }
    protected abstract void DealDamage();
    protected abstract void CalculateDamage();
}