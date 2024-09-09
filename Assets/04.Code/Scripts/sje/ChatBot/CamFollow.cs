using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] 
    private float min = -45f;
    [SerializeField] 
    private float max = 85f;
    [SerializeField]
    private float mouseSensitivity = 100f; // ���콺 ���� ����
    
    public Transform playerBody; // �÷��̾��� ��ü Transform�� ������ ����

    private float _xRotation = 0f; // ī�޶��� x�� ȸ�� 
    
    public Transform target;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = target.position;
    }
}







































