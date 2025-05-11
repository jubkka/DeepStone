public class InputSystems : Systems
{
    public static InputSystems Instance;
    
    private HotbarInput hotbarInput;
    
    public HotbarInput GetHotbarInput => hotbarInput;
    
    private void Awake()
    {
        Instance = this;
        
        GetComponents();
    }
    
    protected override void GetComponents()
    {
        hotbarInput = components.GetComponentInChildren<HotbarInput>();
    }
}