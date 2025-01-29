using System.Collections.Generic;
using UnityEngine;

public class EquipmentModel : MonoBehaviour {

    public EquipmentView equipmentView;
    public Dictionary<string, ItemModel> equipments = new Dictionary<string, ItemModel>()
    {
        {"Helmet", null},
        {"Chestplate", null},
        {"Pants", null},
        {"Boots", null},
        {"Ring", null},
        {"Necklace", null},
    };
}