using UnityEngine;

public class HotbarInputControlUI : MonoBehaviour
{
    [SerializeField] private HotbarInputControl inputControl;
    [SerializeField] private Transform slots;
    [SerializeField] private GameObject activeSlot;

    private void Awake()
    {
        inputControl.OnActiveSlotChanged += MoveActiveSlot;
    }

    private void MoveActiveSlot(int index) 
    {
        activeSlot.transform.SetParent(slots.transform.GetChild(index));
        activeSlot.transform.position = slots.transform.GetChild(index).transform.position;
    }
}