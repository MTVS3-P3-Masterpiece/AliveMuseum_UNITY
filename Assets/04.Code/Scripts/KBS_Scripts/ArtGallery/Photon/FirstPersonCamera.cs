using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float MouseSensitivity = 10f;

    private float verticalRotation;
    private float horizontalRotation;
    
    public bool isTapKeyPressed = false; // TAP Ű�� ���ȴ��� Ȯ��
    private bool isLocked = false; // ī�޶� �����Ǿ����� Ȯ��
    private Quaternion lockedRotation; // ������ ī�޶� ȸ����

    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        transform.position = player.position;

        // TAP Ű�� ���ȴ��� ����
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTapKeyPressed = true;
            if (!isLocked)
            {
                // TAP Ű�� ó�� ������ �� ī�޶��� ���� ȸ�� ���� ����
                lockedRotation = transform.rotation;
                isLocked = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            isTapKeyPressed = false;
            isLocked = false; // TAP Ű�� ���� �� ī�޶� ���� ����
        }

        // ī�޶� �������� �ʾ��� ���� ���콺�� ī�޶� ȸ��
        if (!isLocked)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            verticalRotation -= mouseY * MouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -70f, 70f);

            horizontalRotation += mouseX * MouseSensitivity;

            transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
        }
        else
        {
            // TAP Ű�� ���� ���¿��� ī�޶� ����
            transform.rotation = lockedRotation;
        }
    }
}
