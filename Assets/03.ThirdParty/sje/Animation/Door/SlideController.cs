/*using UnityEngine;

public class SlideController : MonoBehaviour
{
    public GameObject player;
    public float activationDistance = 10.0f;
    private Animator animator;

    public Animator oppositeDoorAnimator;
    public string triggerName = "OpenDoor";

    void Start()
    {

        animator = GetComponent<Animator>();

    }

    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < activationDistance)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(triggerName))
            {
                animator.SetTrigger(triggerName);
                oppositeDoorAnimator.SetTrigger(triggerName);
                Debug.Log("문을 엽니다.");
            }
        }
        else
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("CloseDoor"))
            {
                animator.SetTrigger("CloseDoor");
                oppositeDoorAnimator.SetTrigger("CloseDoor");
                Debug.Log("문을 닫습니다.");
            }
        }
    }
}*/





/*
using UnityEngine;

public class SlideController : MonoBehaviour
{
    public Animator doorAnimator; // 문에 붙어 있는 Animator 컴포넌트
    public string openTriggerName = "OpenDoor"; // 문이 열리는 애니메이션의 트리거 이름
    public string closeTriggerName = "CloseDoor"; // 문이 닫히는 애니메이션의 트리거 이름

    void OnTriggerEnter(Collider other)
    {
        // 트리거 범위에 들어온 오브젝트가 플레이어인지 확인
        if (other.CompareTag("Player"))
        {
            // 문을 여는 애니메이션 트리거
            doorAnimator.SetTrigger(openTriggerName);
            Debug.Log("플레이어가 범위에 들어와서 문이 열립니다.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 트리거 범위에서 플레이어가 나가면 문 닫기
        if (other.CompareTag("Player"))
        {
            // 문을 닫는 애니메이션 트리거
            doorAnimator.SetTrigger(closeTriggerName);
            Debug.Log("플레이어가 범위에서 나가서 문이 닫힙니다.");
        }
    }
}*/



using UnityEngine;

public class ProximityDoorController : MonoBehaviour
{
    public GameObject player; // 플레이어 오브젝트를 드래그하여 연결
    
    public Transform triggerLocation; // 특정 위치를 설정할 Transform
    
    
    
    
   // public float activationDistance = 5.0f; // 문이 열리기 위한 거리
    
   public float activationRadius; // 특정 위치 주위의 반경
    
    
    private Animator animator; // 문 애니메이션을 제어할 Animator 컴포넌트
    private bool isDoorOpen = false; // 문이 열린 상태인지 여부를 기록하는 변수
    
    
    
    
   // public string triggerName = "OpenDoor"; // 트리거 이름
   
   public string openTriggerName = "OpenDoor"; // 문 열기 애니메이션 트리거 이름
    public string closeTriggerName = "CloseDoor"; // 문 닫기 애니메이션 트리거 이름
    
    public float closeAnimationSpeed = 5.0f; // 닫히는 애니메이션의 속도 조절
    
    void Start()
    {
        // 문 오브젝트에서 Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 플레이어와 문 사이의 거리 계산
       // float distance = Vector3.Distance(transform.position, player.transform.position);
       
       // 플레이어와 특정 위치 사이의 거리 계산
       float distance = Vector3.Distance(player.transform.position, triggerLocation.position);

       // 디버깅 로그 출력
       Debug.Log("Distance to trigger location: " + distance);
       
       
       

        /*
        // 플레이어가 특정 거리 안에 들어왔을 때 문 열기 애니메이션 트리거
        if (distance < activationDistance)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(triggerName))
            {
                animator.SetTrigger(triggerName);
                Debug.Log("Door opening...");
                Debug.Log("====================distance==============================" + distance);
            }
        }
        else
        {
            animator.SetTrigger("CloseDoor");
        }
        */
        
        
        if (distance < activationRadius)
        {
            /*// 특정 위치에 가까이 있으면 문 열기 애니메이션 트리거
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("OpenDoor"))
            {
                animator.SetTrigger(openTriggerName);
                Debug.Log("Opening door");
            }*/
            
            // 특정 위치에 가까이 있으면 문 열기 애니메이션 트리거
            if (!isDoorOpen)
            {
                animator.SetTrigger(openTriggerName);
                isDoorOpen = true;
                Debug.Log("Opening door");
            }
            
            
        }
        /*else
        {
            // 특정 위치에서 멀어지면 문 닫기 애니메이션 트리거
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("CloseDoor"))
            {
                animator.SetTrigger(closeTriggerName);
                Debug.Log("Closing door");
            }
        }*/
        else
        {
            // 특정 위치에서 멀어지면 문 닫기 애니메이션 트리거
            if (isDoorOpen)
            {
                
                // 닫히는 애니메이션 속도를 조절
                animator.SetFloat("CloseAnimationSpeed", closeAnimationSpeed);
                
                
                animator.SetTrigger(closeTriggerName);
                isDoorOpen = false;
                Debug.Log("Closing door");
            }
        }
        
        
        
        
        
    }
}














































































































