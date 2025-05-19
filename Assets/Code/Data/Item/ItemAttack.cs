using UnityEngine;

public abstract class ItemAttack : MonoBehaviour
{
    [SerializeField] protected GenericContainer container; 
    protected Camera cam;

    protected virtual void Start()
    {
        cam = Camera.main;
    }

    protected abstract void DealDamage();
}