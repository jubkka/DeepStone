public class UnequipCommand : IItemCommand
{
    private EquipmentComponent equipment;
    private InventoryComponent inventory;
    
    public UnequipCommand(EquipmentComponent equipment, InventoryComponent inventory)
    {
        this.equipment = equipment;
        this.inventory = inventory;
    }

    public void Execute(Item item)
    {
        equipment.UnequipItem(item);
        inventory.AddItem(item, 0);
    }
}