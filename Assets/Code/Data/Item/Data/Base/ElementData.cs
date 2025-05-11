using UnityEngine;
public abstract class ElementData : GenericElementData  {
    #region Fields
        [Header("Item Data")]
        [SerializeField] protected string id;
        [SerializeField] protected int weight;
        [SerializeField] protected int cost;
    #endregion

    #region Properties
        public int GetWeight => weight;
        public int GetCost => cost;
        public string GetId => id;
    #endregion
}


