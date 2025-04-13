using UnityEngine;

public class HotbarInputControlUI : MonoBehaviour
{
    [SerializeField] private Transform slots;
    [SerializeField] private GameObject activeSlot;
    
    private HotbarInputControl inputControl;

    private void Start()
    {
        inputControl = GetComponent<HotbarInputControl>();
        inputControl.OnActiveSlotChanged += MoveActiveSlot;
    }

    private void MoveActiveSlot(int index) 
    {
        activeSlot.transform.SetParent(slots.transform.GetChild(index));
        activeSlot.transform.position = slots.transform.GetChild(index).transform.position;
    }
}