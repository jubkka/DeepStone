public class PotionModel : StackableModel
{
    public PotionModel(ItemData data, int count = 1) : base(data, count) {}

    public override void Use(InventoryPresenter inventoryPresenter, EquipmentPresenter equipmentPresenter)
    {
        count --;
        itemView.Refresh();

        if (count <= 0) itemView.Drop();
    }
}