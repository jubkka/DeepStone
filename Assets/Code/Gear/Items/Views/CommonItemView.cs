using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommonItemView : ItemView, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] protected Image image; 
    [SerializeField] protected TextMeshProUGUI count;
    public Transform parentBeforeDrag;

    #region Events
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) 
        {
            windowActions.ShowWindowActions(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        StartCoroutine(DelayShowAdditional(1));
    }
    
    #endregion

    #region InteractWithItem
    public override void Refresh() 
    {
        if(itemModel.data.GetMaxStackSize > 1) count.text = itemModel.count.ToString();

        image.sprite = itemModel.data.GetIcon;
    }

    public override void Use() 
    {
        windowActions.gameObject.SetActive(false);
        itemModel.Use(inventoryPresenter, equipmentPresenter);
    }

    public override void Drop() 
    {
        windowActions.gameObject.SetActive(false);
        itemModel.Drop(inventoryPresenter);
        Destroy(gameObject);
    }
    #endregion

    #region Coroutines
    IEnumerator DelayShowAdditional(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    #endregion
}