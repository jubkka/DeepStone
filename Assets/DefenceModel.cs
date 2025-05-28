using System;

public class DefenceModel
{
    private float baseDef = 0;
    private float physicalDef = 0;
    private float magicalDef = 0;

    public float PhysicalDef
    {
        get => physicalDef;
        set
        {
            physicalDef = value;
            
            OnPhysicalDefChanged?.Invoke(physicalDef);
        }
    }
    
    public float MagicalDef
    {
        get => magicalDef;
        set
        {
            magicalDef = value;
            
            OnMagicalDefChanged?.Invoke(magicalDef);
        }
    }
    
    public float BaseDef
    {
        get => baseDef;
        set
        {
            baseDef = value;
            
            OnBaseDefChanged?.Invoke(baseDef);
        }
    }

    public event Action<float> OnPhysicalDefChanged;
    public event Action<float> OnMagicalDefChanged;
    public event Action<float> OnBaseDefChanged;

    public DefenceModel(float baseDef)
    {
        this.baseDef = baseDef;
        
        physicalDef = baseDef;
        magicalDef = baseDef;
    }

    public void CalculateDefence(EquipmentComponent equipmentComponent, EffectComponent effectComponent)
    {
        CalculateDefenceBuff(equipmentComponent, effectComponent);
        CalculateDefenceDebuff(equipmentComponent, effectComponent);
    }

    private void CalculateDefenceBuff(EquipmentComponent equipmentComponent, EffectComponent effectComponent)
    {
        ArmorModel armorDef = equipmentComponent.GetDefenceFlat();
        // ArmorModel effectDef = effectComponent.GetDef();
        
        PhysicalDef = baseDef + armorDef.PhysicalDef * (1 + 0f) + 0; // Базовая защита * (100 + процентные баффы) + плоские баффы
        MagicalDef = baseDef + armorDef.MagicalDef * (1 + 0f) + 0; // Базовая защита * (100 + процентные баффы) + плоские баффы
    }

    private void CalculateDefenceDebuff(EquipmentComponent equipmentComponent, EffectComponent effectComponent)
    {
        // physicalDef -= armorDef. 
    }
}

public class ArmorModel
{
    private float physicalDef = 0f;
    private float magicalDef = 0f;
    
    public float PhysicalDef => physicalDef;
    public float MagicalDef => magicalDef;

    public ArmorModel(float physicalDef, float magicalDef)
    {
        this.physicalDef = physicalDef;
        this.magicalDef = magicalDef;
    }
}