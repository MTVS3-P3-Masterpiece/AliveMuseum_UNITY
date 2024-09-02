using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
 
    private CharacterController cc;
    private float yVelocity = 0;
    private float gravity = -5f;
    public bool isJumping = false;
    public float jumpPower = 1;
    public float moveSpeed = 7f;
    private bool isWalking;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");  
        float v = Input.GetAxis("Vertical");  
         
        
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir);
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        if (Input.GetButtonDown("Jump"))
        {
            if (cc.collisionFlags == CollisionFlags.Below)  
            {
                if (isJumping)  
                {
                    isJumping = false;
                    yVelocity = 0;  
                }
            }
        }
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        if (Input.GetButtonDown("Jump") && !isJumping)  
        {
            yVelocity = jumpPower/4;
            isJumping = true;
        }
        transform.position += dir * moveSpeed * Time.deltaTime;
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
