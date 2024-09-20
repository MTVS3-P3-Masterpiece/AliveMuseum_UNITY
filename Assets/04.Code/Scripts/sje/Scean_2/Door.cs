using System.Collections;
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
    public Collider physicalCollider;  
    
    public float delayTime = 3.0f;  
    
    
    void Start()
    {
        anim = transform.GetComponentInChildren<Animator>();
        m_State = EnemyState.Idle;
    }
    
    
    
    
    
 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
     
            if (anim != null)
            {
                anim.SetTrigger("OpenDoor");
                //physicalCollider.enabled = false;
                
                StartCoroutine(DisableColliderWithDelay());
                
            }
        }
    }
    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("OpenDoor", false);
            physicalCollider.enabled = true;  
            
        }
    }
    private IEnumerator DisableColliderWithDelay()
    {
        yield return new WaitForSeconds(delayTime);  
        physicalCollider.enabled = false; 
    }
    
    
    
    
}