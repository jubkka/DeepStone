using UnityEngine;

public class MagicHandComponent : HandComponent
{
    [Header("Hands")]
    [SerializeField] private LeftHandComponent leftHand;
    [SerializeField] private RightHandComponent rightHand;
}