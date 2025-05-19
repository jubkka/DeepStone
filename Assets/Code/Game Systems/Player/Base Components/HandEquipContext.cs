public class HandEquipContext
{
    public RightHandComponent RightHand { get; }
    public LeftHandComponent LeftHand { get; }
    public MagicHandComponent MagicHand { get; }

    public HandEquipContext(RightHandComponent rightHand, LeftHandComponent leftHand, MagicHandComponent magicHand)
    {
        RightHand = rightHand;
        LeftHand = leftHand;
        MagicHand = magicHand;
    }

}