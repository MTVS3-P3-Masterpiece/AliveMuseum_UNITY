using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] 
    private float min = -45f;
    [SerializeField] 
    private float max = 85f;
    [SerializeField]
    private float mouseSensitivity = 100f; // 마우스 감도 설정
    
    public Transform playerBody; // 플레이어의 몸체 Transform을 저장할 변수

    private float _xRotation = 0f; // 카메라의 x축 회전 
    
    public Transform target;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = target.position;
    }
}







































