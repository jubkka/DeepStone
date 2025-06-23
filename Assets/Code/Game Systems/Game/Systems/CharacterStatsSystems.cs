using UnityEngine;

public class CharacterStatsSystems : Systems, ILoad
{
    public static CharacterStatsSystems Instance;
    
    [SerializeField] private AttributeComponent attribute;
    [SerializeField] private LevelComponent level;
    
    public AttributeComponent Attribute => attribute;
    public LevelComponent Level => level;

    public override void Init(BootstrapCharacter character)
    {
        Instance = this;
        
        level.Init(attribute);
        attribute.Init(level);
    }

    public void LoadFromOrigin(Origin origin)
    {
        level.LoadFromOrigin(origin);
        attribute.LoadFromOrigin(origin);
    }

    public void LoadFromSave()
    {
        
    }
}