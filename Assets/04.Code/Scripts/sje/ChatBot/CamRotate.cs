using Fusion;
using Unity.Cinemachine;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [SerializeField] 
    private float min = -45f;
    [SerializeField] 
    private float max = 85f;
    [SerializeField]
    private float mouseSensitivity = 100f; // ���콺 ���� ����
    
    public Transform playerBody; // �÷��̾��� ��ü Transform�� ������ ����
   // public CinemachineCamera playerCamera;

    private float _xRotation = 0f; 
    public float rotSpeed = 200f;
    private float mx = 0;
    private float my = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; 
        
        // ���콺 Ŀ���� ȭ�� �߾ӿ� �����ϰ� ����
        //Cursor.lockState = CursorLockMode.Locked;


       /* if (!Object.HasInputAuthority)
        {
            playerCamera.gameObject.SetActive(false);
        }
        else
        {
            playerCamera.Follow = playerBody;
            playerCamera.LookAt = playerBody;
        } */
    }

    void Update()
    {
  
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        _xRotation -= mouseY;
        // x�� ȸ�� �� ���� (ī�޶� �������� �ʵ���)
        _xRotation = Mathf.Clamp(_xRotation, min, max);

        // ī�޶��� ���� ȸ�� ����
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        // �÷��̾� ��ü�� y�� ȸ�� ���� (�¿� ������)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}






















