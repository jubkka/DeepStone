using System;
using UnityEngine;

public class OriginInfoUI : MonoBehaviour
{
    public event Action<Origin> OnOriginSelected;
    
    public void AddInfo(Origin origin)
    {
        OnOriginSelected?.Invoke(origin);
    }
}