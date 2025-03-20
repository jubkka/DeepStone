using UnityEngine;

public class ChestInteractor : Interactor
{
    private ChestComponent chest;
    private Animation anim;
    private bool isOpen = false;

    private void Start()
    {
        anim = GetComponentInParent<Animation>();
    }

    public override void Interact()
    {
        if (isOpen)
            anim.Play("Closing");  
        else
            anim.Play("Opening");    

        isOpen = !isOpen;
    }
}