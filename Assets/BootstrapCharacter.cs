using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BootstrapCharacter : MonoBehaviour
{
    [Header("Player Objects")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject UI;
    
    [Header("Player Components")]
    [SerializeField] private GearSystems gearSystems;
    [SerializeField] private CharacterStatsSystems characterStatsSystems;
    [SerializeField] private ResourceSystems resourceSystems;
    [SerializeField] private CombatSystems combatSystems;
    [SerializeField] private MovementSystems movementSystems;
    
    
    public GearSystems GearSystems => gearSystems;
    public CharacterStatsSystems CharacterStatsSystems => characterStatsSystems;
    public ResourceSystems ResourceSystems => resourceSystems;
    public CombatSystems CombatSystems => combatSystems;
    
    private ItemUsageSystem itemUsageSystem;
    
    [SerializeField] private Origin origin;

    private void Awake()
    {
        if (origin != null)
        {
            DontDestroy();
            Init();
            LoadFromOrigin();
        }
        
        LateInit();
        CreateItemUsageSystem();

        PlacePlayer();
    }

    private void PlacePlayer()
    {
        if (GameManager.Instance.CurrentLevel > 1)
            player.transform.position = new Vector3(50f, 1f, 50f);
    }

    private void DontDestroy()
    {
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(UI);
        DontDestroyOnLoad(gameObject);
    }

    private void Init()
    {
        gearSystems.Init(this);
        characterStatsSystems.Init(this);
        resourceSystems.Init(this);
        combatSystems.Init(this);
    }

    private void LoadFromOrigin()
    {
        gearSystems.LoadFromOrigin(origin);
        characterStatsSystems.LoadFromOrigin(origin);
        resourceSystems.LoadFromOrigin(origin);
        combatSystems.LoadFromOrigin(origin);
    }

    private void LateInit()
    {
        movementSystems.Init(this);
    }

    private void LoadFromSave()
    {
        
    }

    private void CreateItemUsageSystem()
    {
        itemUsageSystem = new ItemUsageSystem(this);
    }
}