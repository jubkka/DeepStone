public class StackabkeItemPresenter : ItemPresenter
{
    public override void CreateItem(ItemData data, int count = 1)
    {
        itemModel = new PotionModel(data);
        this.count = count;
    }
}