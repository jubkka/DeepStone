using UnityEngine;

public abstract class Binder : MonoBehaviour
{
    protected abstract void LoadSetting();
    protected abstract void Setup();

    private void Subscribe()
    {
        Settings.Instance.OnResetAction += LoadSetting;
    }

    protected virtual void Start()
    {
        Setup();
        LoadSetting();
        Subscribe();
    }
}