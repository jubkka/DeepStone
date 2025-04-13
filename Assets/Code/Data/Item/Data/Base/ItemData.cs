using System;
using UnityEngine;
public abstract class ItemData : ScriptableObject  {
    #region Fields
        [Header("Item Data")]
        [SerializeField] protected GameObject prefab;
        [SerializeField] protected string nameItem;
        [TextArea] [SerializeField] protected string description;
        [SerializeField] protected Sprite icon;
        [SerializeField] protected string id;
        [SerializeField] protected int weight;
        [SerializeField] protected int cost;
    #endregion

    #region Properties
        public GameObject GetPrefab => prefab;
        public string GetName => nameItem;
        public string GetDescription => description;
        public int GetWeight => weight;
        public int GetCost => cost;
        public string GetId => id;
        public Sprite GetIcon => icon;
    #endregion
}


