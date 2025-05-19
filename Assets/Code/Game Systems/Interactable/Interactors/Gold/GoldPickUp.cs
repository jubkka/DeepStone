using UnityEngine;

public class GoldPickUp : Interactable
{
    [SerializeField] private GoldContainer goldContainer;
    [SerializeField] private GameObject itemObj;
    
    public override void Interact()
    {
        AddGold();
    }

    private void AddGold() 
    {
        int goldAmount = goldContainer.GetAmount;

        GoldController goldController = GoldController.Instance;

        goldController.Give(goldAmount);

        Destroy(itemObj);
    }
}