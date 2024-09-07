using UnityEngine;
using UnityEngine.SceneManagement;  

public class Door : MonoBehaviour
{
    
    enum EnemyState
    {
        Idle,  
        DoorOpen
        
    }

    // 에너미 상태 변수
    private EnemyState m_State;

    // 애니메이터 변수
    private Animator anim;
    
    
    void Start()
    {
        anim = transform.GetComponentInChildren<Animator>();
        m_State = EnemyState.Idle;
    }
    
    
    
    
    
 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            // 애니메이션 트리거 실행
            if (anim != null)
            {
                anim.SetTrigger("OpenDoor");
            }
        }
    }
}