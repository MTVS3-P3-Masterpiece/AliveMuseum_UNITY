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

       /* Vector3 direction = new Vector3(0, 0, -offset.z);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = player.position + rotation * direction + new Vector3(0, offset.y, 0);
        
        transform.LookAt(player.position + Vector3.up * 1.5f);
        /* transform.position = target.position;

        

        verticalRotation -= mouseY * MouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -70f, 70f);

        horizontalRotation += mouseX * MouseSensitivity;

        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0); */
       
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
