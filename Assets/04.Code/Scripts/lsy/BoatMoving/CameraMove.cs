using Unity.Mathematics.Geometry;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    /*
     * 카메라 관련 상수들
     */
    private float followSpeed=10f;                                               // 실제 카메라가 따라가는 속도
    private float sensitivity = 500;                                             // 민감도
    private float clampAngle = 70f;                                              // 위아래 시야 각도 제한                                              
    private float minDistance = 1f;                                              // 플레이어 - 카메라 최소 거리
    private float maxDistance = 4f;                                              // 플레이어 - 카메라 최대 거리
    private float smoothness = 10f;                                              
    
    // private float rotX;
    // private float rotY;
    public float finalDistance;
    public Vector3 dirNormalized;
    public Vector4 finalDir;
    
    public Transform objectTofollowBoat;                                            // 카메라가 따라갈 보트 오브젝트 Transform
    public Transform objectTofollowUser;
    public Transform realCamera;                                                // 실제 카메라 Transform
    
    void Start()
    {
        /* 초기 카메라 수치 가져오기 및 커서 설정. */
        // rotX = transform.localRotation.eulerAngles.x;
        // rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.position.normalized;
        finalDistance = realCamera.localPosition.magnitude;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    } 
    void Update()
    {
        // /* 카메라 회전 계산 */
        // rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
        // rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        // rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        //
        // Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        // transform.rotation = rot;
    }
    void LateUpdate()
    {
        /* 카메라 위치 계산 및 이동 */
        transform.position = Vector3.MoveTowards(transform.position, objectTofollowUser.position, followSpeed);
        finalDir = dirNormalized;
        // RaycastHit hit;
        // if (Physics.Linecast(transform.position, finalDir, out hit))    // 장애물 겹칠 시 카메라 위치 조정
        // {
        //      finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        // }
        // else
        // {
        //      finalDistance = maxDistance;
        // }
        //realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized*finalDistance, Time.deltaTime*smoothness);
        realCamera.localPosition = objectTofollowUser.position;
    }
}
