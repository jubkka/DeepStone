using UnityEngine;

public class HotbarInputUI : MonoBehaviour
{
    [SerializeField] private Transform slots;
    [SerializeField] private GameObject activeSlot;
    
    private HotbarInput input;

    private void Start()
    {
        input = GetComponent<HotbarInput>();
        input.OnActiveSlotChanged += MoveActiveSlot;
    }

    private void MoveActiveSlot(int index) 
    {
        activeSlot.transform.SetParent(slots.transform.GetChild(index));
        activeSlot.transform.position = slots.transform.GetChild(index).transform.position;
    }
}