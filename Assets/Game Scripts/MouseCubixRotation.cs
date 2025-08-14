using UnityEngine;

public class MouseCubixRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1.0f;
    private Vector2 lastMousePosition;
    public static bool isDragging = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Cubix.gameOn) {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            if (isDragging)
            {
                Vector2 currentMousePosition = Input.mousePosition;
                Vector2 mouseDelta = currentMousePosition - lastMousePosition;

                if (mouseDelta.magnitude > 0)
                {
                    // Convert screen movement to world space rotation
                    Vector3 cameraSideVector = mainCamera.transform.right;
                    Vector3 cameraUpVector = mainCamera.transform.up;

                    // Create rotation based on camera orientation
                    Quaternion rotation = Quaternion.AngleAxis(-mouseDelta.x * rotationSpeed, cameraUpVector) *
                                    Quaternion.AngleAxis(mouseDelta.y * rotationSpeed, cameraSideVector);

                    // Apply rotation to the object
                    transform.rotation = rotation * transform.rotation;
                }

                lastMousePosition = currentMousePosition;
            }
        }
        
    }
}