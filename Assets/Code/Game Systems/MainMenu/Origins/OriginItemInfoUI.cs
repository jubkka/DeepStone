using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OriginItemInfoUI : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private OriginsUI originsUI;
    [SerializeField] private Transform content;

    private void Awake() => originsUI.OnOriginSelected += AddItems;
    
    private void AddItems(Origin origin)
    {
        ClearItems();
        
        foreach (var item in origin.GetItems)
            AddItem(item);
    }

    private void AddItem(Item item)
    {
        GameObject newItem = Instantiate(itemPrefab, content);
        
        Image image = newItem.GetComponentInChildren<Image>();
        TextMeshProUGUI tmp = newItem.GetComponentInChildren<TextMeshProUGUI>();

        image.sprite = item.data.GetIcon;
        tmp.text = item.data.name;
    }

    private void ClearItems()
    {
        foreach (Transform item in content)
            Destroy(item.gameObject);
    }
}
