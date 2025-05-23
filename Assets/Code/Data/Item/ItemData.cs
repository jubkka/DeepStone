using UnityEngine;
public abstract class ItemData : ScriptableObject {
    #region Fields
        [Header("Item Data")]
        [SerializeField] protected string nameItem;
        [TextArea] [SerializeField] protected string description;
        [SerializeField] protected Sprite icon;
        [SerializeField] protected int id;
        [SerializeField] protected int weight;
        [SerializeField] protected int cost;
    #endregion

    #region Properties
        public string GetName => nameItem;
        public string GetDescription => description;
        public int GetWeight => weight;
        public int GetCost => cost;
        public int GetId => id;
        public Sprite GetIcon => icon;
    #endregion

    public abstract void Use();
}


