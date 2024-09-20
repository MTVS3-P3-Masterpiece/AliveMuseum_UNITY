using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float MouseSensitivity = 10f;

    private float verticalRotation;
    private float horizontalRotation;

    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        transform.position = player.position;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        verticalRotation -= mouseY * MouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -70f, 70f);

        horizontalRotation += mouseX * MouseSensitivity;

        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
    }
}
