using Cinemachine;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Vector2 minBounds, maxBounds; // X/Z movement limits
    public float moveSpeed = 0.1f; // Adjust the camera movement sensitivity

    private Vector2 lastTouchPosition;
    private bool isDragging;

    void Update()
    {
        HandleSwipeInput();
    }

    void HandleSwipeInput()
    {
        if (Input.touchCount == 1) // Detect single touch
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) // Start swipe
            {
                isDragging = true;
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // While dragging
            {
                if (!isDragging) return;

                // Calculate the distance moved from the last position to the current position
                Vector2 delta = touch.position - lastTouchPosition;
                lastTouchPosition = touch.position;

                // Convert the touch delta to world-space movement based on the screen size
                float moveX = delta.x * moveSpeed * Camera.main.orthographicSize / Screen.height;
                float moveZ = delta.y * moveSpeed * Camera.main.orthographicSize / Screen.height;

                // Move the camera based on the touch delta
                transform.position -= new Vector3(moveX, 0, moveZ); // Move the camera opposite to the touch movement

                // Restrict movement within bounds
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
                    transform.position.y, // Keep height fixed
                    Mathf.Clamp(transform.position.z, minBounds.y, maxBounds.y)
                );
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) // Stop dragging
            {
                isDragging = false;
            }
        } else if (Input.touchCount > 1){
            isDragging = false;
        }
    }
    public void SetCameraPosition(Vector3 newPosition)
    {
        transform.position = new Vector3(
            Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x),
            transform.position.y, // Keep Y the same
            Mathf.Clamp(newPosition.z, minBounds.y, maxBounds.y)
        );
    }

    public void SetCameraZoom(float newSize)
    {
        if (virtualCamera != null)
        {
            virtualCamera.m_Lens.OrthographicSize = newSize;
        }
    }
}
