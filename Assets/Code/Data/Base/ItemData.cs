using UnityEngine;

[CreateAssetMenu(fileName = "TestItem", menuName = "Items/TestItem")]
public class ItemData : ScriptableObject {
    #region Fields
        [SerializeField] private string nameItem;
        [TextArea]
        [SerializeField] private string description;
        [SerializeField] private Sprite icon;
        [SerializeField] private int id;
        [SerializeField] private int weight;
        [SerializeField] private int cost;
        [SerializeField] private bool stackable;
        [SerializeField] private int maxStackSize;
    #endregion

    #region Properties
        public string GetName { get => nameItem; }
        public string GetDescription { get => description; }
        public int GetWeight { get => weight; }
        public int GetCost { get => cost; }
        public int GetId { get => id;  }
        public bool IsStackable { get => stackable; }
        public int GetMaxStackSize { get => maxStackSize; }
        public Sprite GetIcon { get => icon; }
    #endregion
}


