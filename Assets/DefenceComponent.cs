using System;
using UnityEngine;

public class DefenceComponent : MonoBehaviour
{
    [SerializeField] private DefenceView physicalDefenceView;
    [SerializeField] private DefenceView magicalDefenceView;
    
    private EquipmentComponent equipmentComponent;
    private EffectComponent effectComponent;
    
    private DefenceModel model;
    
    public float PhysicalDef => model.PhysicalDef;
    public float MagicalDef => model.MagicalDef;
    
    public event Action<float> OnPhysicalDefenceChanged
    {
        add => model.OnPhysicalDefChanged += value;
        remove => model.OnPhysicalDefChanged -= value;
    }
    
    public event Action<float> OnMagicalDefChanged
    {
        add => model.OnMagicalDefChanged += value;
        remove => model.OnMagicalDefChanged -= value;
    }
    
    public event Action<float> OnBaseDefChanged
    {
        add => model.OnBaseDefChanged += value;
        remove => model.OnBaseDefChanged -= value;
    }

    public void InitFromOrigin(Origin origin,EquipmentComponent equipment, EffectComponent effect)
    {
        equipmentComponent = equipment;
        effectComponent = effect;

        equipmentComponent.OnDefenceChanged += CalculateDefence;
        //effectComponent.OnDefenceEffectChanged += CalculateDef;

        model = new(10); //origin.GetBaseDefence
        
        CalculateDefence();
        
        InitUI();
    }

    private void InitUI()
    {
        physicalDefenceView.Init(this);
        magicalDefenceView.Init(this);
    }

    public void InitFromSave()
    {
        
    } //TODO

    private void CalculateDefence()
    {
        model.CalculateDefence(equipmentComponent, effectComponent);
    }
}