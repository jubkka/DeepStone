using UnityEngine;

public class ResourceSystems : Systems, ILoad
{
    public static ResourceSystems Instance;

    [SerializeField] private GoldComponent gold;
    [SerializeField] private WeightComponent weight;

    public GoldComponent Gold => gold;
    public WeightComponent Weight => weight;
    
    public override void Init(BootstrapCharacter character)
    {
        Instance = this;
        
        gold.Init();
        weight.Init(
            character.CharacterStatsSystems.Attribute, 
            character.GearSystems);
    }

    public void LoadFromOrigin(Origin origin)
    {
        gold.LoadFromOrigin(origin);
        weight.LoadFromOrigin(origin);
    }

    public void LoadFromSave() //TODO
    {
        
    }
}