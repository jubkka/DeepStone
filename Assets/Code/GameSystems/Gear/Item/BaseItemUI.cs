using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseItemUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    #region Varibales
    
        [Header("Game Objects")]
        protected TextMeshProUGUI TMP;
        protected Image icon;
        public GearComponent gear;
    
        [Header("Properties")]
        public int index;
        [SerializeField] protected float alphaInDrag = 0.7f;
        protected Item item;
    
        [Header("DragAndDrop")]
        public Transform beforeDragParent;
        public Transform afterDragParent;
        public Transform dragContainer;
    #endregion
    
    #region Functions
        private void Awake() 
        {
            TMP = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            icon = GetComponent<Image>();
        }
        public void Initialize(Item item, int index) 
        {
            this.index = index;
            this.item = item;
    
            item.onChanged += UpdateItem;
            
            UpdateItem();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            ChangeStateIcon(false, alphaInDrag);
    
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
            ChangeStateIcon(true, 1f);
        }
        public void OnPointerClick(PointerEventData eventData) 
        {
            if (eventData.button == PointerEventData.InputButton.Right) Debug.Log("Right click!");
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
        protected void ChangeStateIcon(bool raycastState, float alpha)
        {
            icon.raycastTarget = raycastState; // Взаимодействие с иконкой
            icon.color = new Color(255,255,255, alpha); // Прозрачность иконки
            TMP.color = new Color(255,255,255, alpha); // Прозрачность текста
        } 

        public void Drop() 
        {
            gear.RemoveItem(index);
        }
        public abstract void HandleDrop(GearComponent gear);
    #endregion
}