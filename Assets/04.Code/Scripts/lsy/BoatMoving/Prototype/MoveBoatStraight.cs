using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MoveBoat : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5f;
    public List<Transform> targetPositions = new List<Transform>();

    private bool isResponseDone = false;
    
    //[SerializeField] float accelPower = 1f;
    //[SerializeField] float rotatePower = 1f;

    //private float rotateAmount, direction;
    void Start()
    {
        StartCoroutine(MoveToTargetPos());

    }

    // private void FixedUpdate()
    // {
    //     rotateAmount -= Input.GetAxis("Horizontal");
    //     speed = Input.GetAxis("Vertical") * accelPower;
    //
    //     direction = Mathf.Sign(Vector3.Dot(rb.velocity, rb.GetRelativePointVelocity(Vector3.up)));
    //
    //     rb.rotation += Quaternion.Euler(rotateAmount + rotatePower + rb.velocity * direction);
    //     
    //     rb.AddRelativeForce(Vector3.up + speed);
    //     
    //     rb.AddRelativeForce(-Vector3.right * rb.velocity.magnitude * rotateAmount/2);
    // }

    // void Update()
    // {
    //     //FIXME : 도착지점 근처에서 감속 시점 조절 필요
    //     transform.position = Vector3.Lerp(transform.position, targetPositions[0].position, speed * Time.deltaTime);
    // }

    IEnumerator MoveToTargetPos()
    {
        while (transform.position != targetPositions[0].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPositions[0].position, speed * Time.deltaTime);
            yield return null; // 다음 프레임까지 대기
        }
        // 텍스트 입력 및 req, res 완료 시
        yield return new WaitForSeconds(1f);
        while (transform.position != targetPositions[1].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPositions[1].position, speed * Time.deltaTime);
            yield return null; // 다음 프레임까지 대기
        }
        
    }
}
