using UnityEngine;

public abstract class GenericContainer : MonoBehaviour
{
    protected Item item = new ();
    public Item GetItem => item;
    public abstract GenericElementData Data { get; }

    [SerializeField] protected InfoPanelWorldSpace infoPanel;

    protected virtual void Start() => infoPanel.SetData(item.data);

    public void CreateNewItem(Item newItem)
    {
        item = newItem;
    }
}