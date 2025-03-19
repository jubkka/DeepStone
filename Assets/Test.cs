using UnityEngine;

public class Test : MonoBehaviour
{
    Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8)) anim.Play("Opening");    
        if (Input.GetKeyDown(KeyCode.Alpha9)) anim.Play("Closing");    
    }
}
