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
    private float mouseSensitivity = 100f; // 마우스 감도 설정
    
    public Transform playerBody; // 플레이어의 몸체 Transform을 저장할 변수
   // public CinemachineCamera playerCamera;

    private float _xRotation = 0f; 
    public float rotSpeed = 200f;
    private float mx = 0;
    private float my = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; 
        
        // 마우스 커서를 화면 중앙에 고정하고 숨김
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
        // x축 회전 값 제한 (카메라가 뒤집히지 않도록)
        _xRotation = Mathf.Clamp(_xRotation, min, max);

        // 카메라의 로컬 회전 적용
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        // 플레이어 몸체의 y축 회전 적용 (좌우 움직임)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}






















