using UnityEngine;

public abstract class ItemAttack : MonoBehaviour
{
    protected Transform cam;
    protected ItemContainer itemContainer;
    
    protected void Start()
    {
        cam = Camera.main.transform;
        itemContainer = GetComponentInChildren<ItemContainer>();
    }

    protected abstract void DealDamage();
}