using UnityEngine;

public class GoldPickUp : Interactable
{
    private GameObject itemObj;

    private void Awake()
    {
        itemObj = transform.parent.gameObject;
    }
    
    public override void Interact()
    {
        AddGold();
    }

    private void AddGold() 
    {
        int goldAmount = GetComponent<GoldContainer>().GetAmount;

        GoldController goldController = GoldController.Instance;

        goldController.Give(goldAmount);

        Destroy(itemObj);
    }
}