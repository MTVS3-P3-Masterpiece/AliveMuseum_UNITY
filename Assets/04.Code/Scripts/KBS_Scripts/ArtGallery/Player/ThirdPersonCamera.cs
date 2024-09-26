using System;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; //플레이어와 카메라 사이 거리
    public float rotationSpeed = 5.0f;
    public float minYAngle = -20f;
    public float maxYAngle = 60f;

    private float currentX = 0f;
    private float currentY = 0f;

    public float Distance = 5.0f;
    public float Height = 2.0f;
    public float MouseSensitivity = 10f;
    private float verticalRotation;
    private float horizontalRotation; 

   private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        
       float mouseX = Input.GetAxis("Mouse X");
       float mouseY = Input.GetAxis("Mouse Y");
       
       verticalRotation -= mouseY * MouseSensitivity;
       verticalRotation = Mathf.Clamp(verticalRotation, -70f, 70f);

       // 수평 회전 (좌/우)
       horizontalRotation += mouseX * MouseSensitivity;

       // 카메라의 회전 계산 (캐릭터를 중심으로 회전)
       Quaternion rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);

       // 카메라의 위치 계산 (플레이어의 위치에서 일정한 거리와 높이를 유지)
       Vector3 offset = new Vector3(0, Height, -Distance);
       transform.position = player.position + rotation * offset;

       // 카메라가 플레이어를 바라보도록 설정
       transform.LookAt(player.position + Vector3.up * 1.5f);
       
       
       
    }

    
}
