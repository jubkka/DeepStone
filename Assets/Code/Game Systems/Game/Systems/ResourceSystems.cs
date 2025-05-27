using UnityEngine;

public class ResourceSystems : Systems
{
    public static ResourceSystems Instance;

    [SerializeField] private GoldComponent gold;

    public GoldComponent Gold => gold;
    
    protected override void Init()
    {
        Instance = this;
    }

    public override void LoadFromOrigin(Origin origin)
    {
        Init();
        
        gold.LoadFromOrigin(origin);
    }

    public override void LoadFromSave() //TODO
    {
        Init();
    }
}