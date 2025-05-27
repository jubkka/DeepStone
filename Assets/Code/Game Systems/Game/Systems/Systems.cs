using UnityEngine;

public abstract class Systems : MonoBehaviour
{
    protected abstract void Init();
    
    public abstract void LoadFromOrigin(Origin origin);
    public abstract void LoadFromSave();
}