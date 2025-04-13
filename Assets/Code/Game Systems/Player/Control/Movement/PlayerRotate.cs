using UnityEngine;

public class PlayerRotate : MonoBehaviour, IPausable
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float upperVerticalRotationLimit; 
    [SerializeField] private float lowerVerticalRotationLimit; 
    
    private GameObject player;
    private Camera playerCamera;
    private float xRotation;
    private float yRotation;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerCamera = Camera.main;
    }
    private void Update()
    {
        Rotate();
    }
    private void Rotate() 
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 2 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 2 * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -lowerVerticalRotationLimit, upperVerticalRotationLimit);

        yRotation += mouseX;
        
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void OnPause(bool isPaused)
    {
        enabled = !isPaused;
    }
}
