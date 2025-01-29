public class WearableModel : SimpleModel {
    public WearableModel(ItemData data) : base(data) {}

    public override void Use(InventoryPresenter inventoryPresenter, EquipmentPresenter equipmentPresenter)
    {
        ArmorData armorData = (ArmorData)data;
        ItemModel armor = equipmentPresenter.equipmentModel.equipments[armorData.GetSlotEquipment];

        if (armor != null) 
        {
            inventoryPresenter.AddItem(armor);
            equipmentPresenter.equipmentModel.equipmentView.TakeOffArmor(armorData.GetSlotEquipment);
        }

        inventoryPresenter.RemoveItem(itemView.GetIndex);
        equipmentPresenter.WearItem(this, armorData.GetSlotEquipment);
    }
}