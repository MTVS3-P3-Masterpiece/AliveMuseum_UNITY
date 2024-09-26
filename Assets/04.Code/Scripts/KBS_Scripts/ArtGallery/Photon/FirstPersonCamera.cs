using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float MouseSensitivity = 10f;

    private float verticalRotation;
    private float horizontalRotation;
    
    public bool isTapKeyPressed = false; // TAP 키가 눌렸는지 확인
    private bool isLocked = false; // 카메라가 고정되었는지 확인
    private Quaternion lockedRotation; // 고정된 카메라 회전값

    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        transform.position = player.position;

        // TAP 키가 눌렸는지 감지
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTapKeyPressed = true;
            if (!isLocked)
            {
                // TAP 키를 처음 눌렀을 때 카메라의 현재 회전 값을 저장
                lockedRotation = transform.rotation;
                isLocked = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            isTapKeyPressed = false;
            isLocked = false; // TAP 키를 뗐을 때 카메라 고정 해제
        }

        // 카메라가 고정되지 않았을 때만 마우스로 카메라 회전
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
            // TAP 키가 눌린 상태에서 카메라를 고정
            transform.rotation = lockedRotation;
        }
    }
}
