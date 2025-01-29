using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private GameObject character;

    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float upperVerticalRotationLimit; 
    [SerializeField] private float lowerVerticalRotationLimit; 
    private float xRotation;
    private float yRotation;

    private void Start() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 2 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 2 * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -lowerVerticalRotationLimit, upperVerticalRotationLimit);

        yRotation += mouseX;
        
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        character.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
