public class EquipmentPresenter : GearPresenter
{
    public EquipmentModel equipmentModel;
    public InventoryPresenter inventoryPresenter;

    public void WearItem(ItemModel item, string armorIndex) 
    {
        equipmentModel.equipments[armorIndex] = item;
        equipmentModel.equipmentView.WearArmor(armorIndex, item.itemView);
    }
}