using UnityEngine;

public class GoldPickUp : Interactable
{
    [SerializeField] private GoldContainer goldContainer;
    [SerializeField] private GameObject itemObj;

    private int goldAmount;

    private void Awake()
    {
        goldAmount = goldContainer.GetAmount;
    }

    public override void Interact()
    {
        AddGold();
        
        SFXAudioManager.Instance.PlaySound("PickUpGold");
    }

    private void AddGold() 
    {
        GoldComponent goldComponent = ResourceSystems.Instance.Gold;

        goldComponent.Give(goldAmount);
        Destroy(itemObj);
    }
}