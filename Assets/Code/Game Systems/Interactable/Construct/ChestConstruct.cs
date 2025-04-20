using UnityEngine;

public class ChestConstruct : Construct
{
    [SerializeField] private int chanceToDropItem;
    private ChestContainer chestContainer;
    
    protected override void Start()
    {
        parent = transform.parent.gameObject;
        chestContainer = GetComponent<ChestContainer>();
    }

    protected override void Deconstruct()
    {
        DropItems();
        Destroy(parent);
    }

    private void DropItems()
    {
        foreach (var item in chestContainer.Items)
        {
            if (Random.Range(0, 100) <= chanceToDropItem)
                SpawnItem(item);
        }
    }

    private void SpawnItem(Item item)
    {
        Instantiate(item.data.GetPrefab, transform.position, Quaternion.identity);
    }
}