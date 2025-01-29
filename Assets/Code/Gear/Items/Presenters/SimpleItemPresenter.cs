public class SimpleItemPresenter : ItemPresenter 
{
    public override void CreateItem(ItemData data, int count = 1)
    {
        itemModel = new SimpleModel(data);
        this.count = count;
    }
}