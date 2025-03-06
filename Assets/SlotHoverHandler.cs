using System;
using UnityEngine;

public class SlotHoverHandler : MonoBehaviour
{
    public void MoveActiveSlot(Transform slots,int indexSlot)
    {
        gameObject.SetActive(true);
        transform.SetParent(slots.GetChild(indexSlot));
        transform.position = slots.GetChild(indexSlot).position;
    }

    public void HideActiveSlot() 
    {
        gameObject.SetActive(false);
    }
}
