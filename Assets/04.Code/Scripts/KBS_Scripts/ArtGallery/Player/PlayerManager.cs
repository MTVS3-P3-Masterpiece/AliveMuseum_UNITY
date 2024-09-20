using System.Collections;
using Fusion;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;  

public class PlayerManager : NetworkBehaviour
{
    public float moveSpeed = 4f;
    private CharacterController cc;
    private float gravity = -20f;   
    private float yVelocity = 0;
    public float jumpPower = 10f; 
    public bool isJumping = false;
    public int hp = 20;    
    private int maxHp = 20;
    public Slider hpSlider;
    public GameObject hitEffect; 
    //private Animator anim;
    public Transform cameraTransform;
    public TMP_Text nicknameText;
    public Camera camera;
    public static PlayerManager Instance;

   
    
    void Awake()
    {
        cc = GetComponent<CharacterController>();
        //anim = GetComponentInChildren<Animator>();
        
    }

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            Instance = this;
            RpcSecNickName(CreateNickname.Value);
            camera = Camera.main;
            //camera.GetComponent<ThirdPersonCamera>().player = transform; 
            camera.GetComponent<FirstPersonCamera>().player =  transform;
        }
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RpcSecNickName(string nickname)
    {
        nicknameText.text = nickname;
        Debug.Log($"OnNicknameChanged : {nickname}");
    }
    
    public override void FixedUpdateNetwork()
    {
        if (!HasStateAuthority)
            return;
        
        float h = Input.GetAxis("Horizontal");  
        float v = Input.GetAxis("Vertical");


        Vector3 dir = new Vector3(h, 0, v).normalized;

        Quaternion cameraRotationY = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0);
        Vector3 move = cameraRotationY * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Runner.DeltaTime * moveSpeed;

        move *= Runner.DeltaTime * moveSpeed;

        cc.Move(move);

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

    private void CameraPosition()
    {
        Vector3 cameraPosition = cameraTransform.localPosition;
        cameraTransform.localPosition = cameraPosition;
    }
    
}
