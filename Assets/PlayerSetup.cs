using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private Origin selectedOrigin;
    public Origin SelectedOrigin => selectedOrigin;
    
    public static PlayerSetup Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    public void SelectOrigin(Origin origin) => selectedOrigin = origin;
}