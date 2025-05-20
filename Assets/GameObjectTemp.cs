using UnityEngine;

public class GameObjectTemp : MonoBehaviour
{
    [SerializeField] private bool destroyOnLoad = false;
    
    void Awake()
    {
        if (destroyOnLoad)
            Destroy(gameObject);
    }
}
