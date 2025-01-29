using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 1;

    private void Update() 
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = characterController.transform.right * moveX + characterController.transform.forward * moveZ;

        characterController.Move(move * speed * Time.deltaTime);
    }
}
