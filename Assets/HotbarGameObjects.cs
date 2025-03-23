using System;
using UnityEngine;

public class HotbarGameObjects : MonoBehaviour
{
    [SerializeField] private HotbarInputControl hotbarInputControl;
    [SerializeField] private Transform activeGameObject;
    [SerializeField] private GameObject[] gameObjects;

    private void Start()
    {
        gameObjects = new GameObject[HotbarComponent.Instance.maxSize];

        Subscribe();    
    }

    private void Subscribe() 
    {
        hotbarInputControl.OnActiveSlotChanged += SetActiveGameObject;
    }

    private void SetActiveGameObject(int index) 
    {
        if(activeGameObject.childCount > 0) 
            Destroy(activeGameObject.GetChild(0).gameObject);
        
        ItemData itemData = HotbarComponent.Instance.GetItem(index).data;

        if(itemData != null)
            Instantiate(itemData.GetPrefab, activeGameObject);
    }

    public void CreateObject(Item item, int index) 
    {
        GameObject gameObject = Instantiate(item.data.GetPrefab, transform);
        gameObject.SetActive(false);
        gameObjects[index] = gameObject;
    }

    public void DestroyObject(int index) 
    {
        gameObjects[index] = null;
    }

    public void MoveObjects(int fromIndex, int targetIndex) 
    {
        (gameObjects[fromIndex], gameObjects[targetIndex]) = 
        (gameObjects[targetIndex], gameObjects[fromIndex]);
    }
}
