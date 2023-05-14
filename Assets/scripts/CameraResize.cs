using UnityEngine;

public class CameraResize : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        float height = Screen.height;
        float width = Screen.width;

        float targetHeight = height / 2f; // You can adjust this value to your liking
        float targetWidth = width / height * targetHeight;

        cam.orthographicSize = targetHeight / 2f;
        cam.aspect = targetWidth / targetHeight;
    }
}
