using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;  

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    private CharacterController cc;
    private float gravity = -20f;   
    private float yVelocity = 0;
    public float jumpPower = 10f; 
    public bool isJumping = false;
    public int hp = 20;    
    private int maxHp = 20;
    public Slider hpSlider;
    public GameObject hitEffect; 
    private Animator anim; 
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined; 
                
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
            yVelocity = jumpPower;
            isJumping = true;
        }
        transform.position += dir * moveSpeed * Time.deltaTime;
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }

    public void DamageAction(int damage)
    {
        hp -= damage;
        
        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
        
    }
    
}
