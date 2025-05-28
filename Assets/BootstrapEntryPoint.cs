using UnityEngine;

public class BootstrapEntryPoint : MonoBehaviour
{
    [SerializeField] private GearSystems gearSystems;
    [SerializeField] private CharacterStatsSystems characterStatsSystems;
    [SerializeField] private ResourceSystems resourceSystems;
    [SerializeField] private CombatSystems combatSystems;
    [SerializeField] private AudioSystems audioSystems;
    
    private ItemUsageSystem itemUsageSystem;
    
    [SerializeField] private Origin origin;

    private void Awake()
    {
        if (origin != null)
            LoadFromOrigin();
        
        CreateItemUsageSystem();
    }
    
    private void LoadFromOrigin()
    {
        gearSystems.LoadFromOrigin(origin);
        characterStatsSystems.LoadFromOrigin(origin, gearSystems.Inventory, gearSystems.Equipment);
        resourceSystems.LoadFromOrigin(origin);
        combatSystems.LoadFromOrigin(origin);
    }

    private void LoadFromSave()
    {
        
    }

    private void CreateItemUsageSystem()
    {
        itemUsageSystem = new ItemUsageSystem(gearSystems, characterStatsSystems, combatSystems);
    }
}
