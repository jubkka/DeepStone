using UnityEngine;

public abstract class Systems : MonoBehaviour
{
    [SerializeField] protected GameObject components;
    protected abstract void GetComponents();
}