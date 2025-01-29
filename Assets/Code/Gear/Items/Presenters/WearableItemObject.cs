public class WearableItemObject : ItemPresenter {
    public override void CreateItem(ItemData data, int count = 1)
    {
        itemModel = new WearableModel(data);
        this.count = count;
    }
}