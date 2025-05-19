public class EquipCommand : IItemCommand
{
    private EquipmentComponent equipment;
    
    public EquipCommand(EquipmentComponent equipment)
    {
        this.equipment = equipment;
    }

    public void Execute(Item item)
    {
        equipment.Equip(item);
    }
}