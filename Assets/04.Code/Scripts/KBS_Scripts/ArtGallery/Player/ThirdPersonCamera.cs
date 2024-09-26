using System;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; //�÷��̾�� ī�޶� ���� �Ÿ�
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

       // ���� ȸ�� (��/��)
       horizontalRotation += mouseX * MouseSensitivity;

       // ī�޶��� ȸ�� ��� (ĳ���͸� �߽����� ȸ��)
       Quaternion rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);

       // ī�޶��� ��ġ ��� (�÷��̾��� ��ġ���� ������ �Ÿ��� ���̸� ����)
       Vector3 offset = new Vector3(0, Height, -Distance);
       transform.position = player.position + rotation * offset;

       // ī�޶� �÷��̾ �ٶ󺸵��� ����
       transform.LookAt(player.position + Vector3.up * 1.5f);
       
       
       
    }

    
}
