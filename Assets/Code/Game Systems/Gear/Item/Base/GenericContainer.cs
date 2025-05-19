using UnityEngine;

public abstract class GenericContainer : MonoBehaviour
{
    protected Item item = new ();
    public Item GetItem => item;

    protected abstract void Start();

    public void CreateNewItem(Item newItem)
    {
        item = newItem;
    }
}