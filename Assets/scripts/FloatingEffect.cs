using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float floatSpeed = 1f; // Speed of the floating effect
    public float floatAmount = 0.5f; // Amount of vertical float movement
    public float tiltAngle = 10f; // Maximum tilt angle

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculate the vertical offset based on time
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmount;

        // Update the sprite's position
        transform.position = startPos + new Vector3(0f, yOffset, 0f);

        // Calculate the tilt angle based on the vertical offset
        float tilt = yOffset * tiltAngle;

        // Apply the tilt rotation around the Z-axis
        transform.rotation = Quaternion.Euler(0f, 0f, tilt);
    }
}