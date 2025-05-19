using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseItemUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    #region Varibales
        [Header("Properties")]
        public int index;
        [SerializeField] protected float alphaInDrag = 0.7f;
        [SerializeField] protected Item item;
        
        [Header("Components")]
        [SerializeField] protected TextMeshProUGUI TMP;
        [SerializeField] protected Image icon;
        public GearComponent gear;
    
        [Header("DragAndDrop")]
        public Transform beforeDragParent;
        public Transform afterDragParent;
        public Transform dragContainer;
    #endregion
    
    #region Functions
        public void Initialize(Item newItem, int newIndex) 
        {
            index = newIndex;
            item = newItem;
    
            item.OnItemChanged += UpdateItem;
            
            UpdateItem();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            ToggleStateIcon(false, alphaInDrag);
    
            beforeDragParent = transform.parent;
            transform.SetParent(dragContainer);
        }
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }
        public void OnEndDrag(PointerEventData eventData) 
        {
            SetTransformParent(beforeDragParent);
            ToggleStateIcon(true, 1f);
        }
        public virtual void OnPointerClick(PointerEventData eventData) 
        {
            if (eventData.button == PointerEventData.InputButton.Right) 
                Use();
            else if (eventData.button == PointerEventData.InputButton.Middle) 
                Drop();
        }
        protected void UpdateItem()
        {
            icon.sprite = item.data.GetIcon;
            TMP.text = item.data is StackableItemData ? item.Amount.ToString() : "";
        }
        protected void SetTransformParent(Transform newParent)
        {
            transform.SetParent(newParent);
            transform.position = newParent.position;
        }
        protected void ToggleStateIcon(bool raycastState, float alpha)
        {
            icon.raycastTarget = raycastState; // Взаимодействие с иконкой
            icon.color = new Color(255,255,255, alpha); // Прозрачность иконки
            TMP.color = new Color(255,255,255, alpha); // Прозрачность текста
        }

        protected virtual void Use() {}
        public void Drop() 
        {
            gear.DropItem(index);
        }
        public abstract void HandleDrop(GearComponent gear);
    #endregion
}