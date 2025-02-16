using UnityEngine;
using UnityEngine.InputSystem;

public class MapController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera mapCamera;
    public GameObject runningGameUI;
    private bool clicked = true;
    public float zoomSpeed = 5f;
    public GameManager gameManager;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (clicked)
            {
                mainCamera.enabled = false;
                mapCamera.enabled = true;
                gameManager.ShowMap();
                clicked = false;
            }
            else
            {
                mainCamera.enabled = true;
                mapCamera.enabled = false;
                gameManager.ResumeGame();
                clicked = true;
            }

        }

        if (Mouse.current.scroll.ReadValue().y * 0.01f > 0) // Zoom In
            mapCamera.orthographicSize -= zoomSpeed;

        if (Mouse.current.scroll.ReadValue().y * 0.01f < 0) // Zoom Out
            mapCamera.orthographicSize += zoomSpeed;

        mapCamera.orthographicSize = Mathf.Clamp(mapCamera.orthographicSize, 5f, 130f); // Limits
    }


}
