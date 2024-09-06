using UnityEngine;

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
}