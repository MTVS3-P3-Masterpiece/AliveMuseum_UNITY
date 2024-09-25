using System.Collections;
using Fusion;
using UnityEngine;

public class TalkingToChange : MonoBehaviour
{
       public GameObject viewPos;
    public GameObject interaction;
    public GameObject ChatText;
    bool enterOk = false;
    bool chatOpen = false;
    private bool followPlayer = false;  
    private bool isChatBotVisible = true; 

    //PlayerMove playerScript;
    private PlayerManager _playerManager;
    GameObject player;  
    //CamRotate camRotate;  
    private FirstPersonCamera firstPersonCamera;
    private CharacterController characterController;  
    private NetworkCharacterController mNetworkCharacterController;  
    
    NetworkRunner runner;  // Fusion의 NetworkRunner


    [SerializeField]
    private float smoothTime = 0.3f; 
    private Vector3 velocity = Vector3.zero;  

    IEnumerator CheckAndWarp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); 
        
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        }
    }
 
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
        player = GameObject.Find("Player");
        //playerScript = player.GetComponent<PlayerMove>();
        //_playerManager = player.GetComponent<PlayerManager>();
        //firstPersonCamera = Camera.main.GetComponent<FirstPersonCamera>();
        //characterController = player.GetComponent<CharacterController>();  
        mNetworkCharacterController = player.GetComponent<NetworkCharacterController>();  
        
        runner = FindObjectOfType<NetworkRunner>(); // NetworkRunner 가져오기
        
        
        if (runner == null)
        {
            Debug.LogError("NetworkRunner not found!");
        }

        
    }


    void Update()
    {
        if (enterOk == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChatText.SetActive(true);
                //playerScript.enabled = false;
                _playerManager.enabled = false;
                chatOpen = true;
                followPlayer = true;  
                interaction.SetActive(false);
                firstPersonCamera.enabled = false;
                characterController.enabled = false;  
                mNetworkCharacterController.enabled = false;  
                
                runner.ProvideInput = false;
                
                if (mNetworkCharacterController != null)
                {
                    mNetworkCharacterController.Velocity = Vector3.zero;
                }
                
                // Cursor.lockState = CursorLockMode.None;  
                // Cursor.visible = true;
                
            }
        }

        if (followPlayer && player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        }

        //if (Input.GetKeyDown(KeyCode.X))
        if (Input.GetKeyDown(KeyCode.X) && chatOpen)
        {
            ChatText.SetActive(false);
            //playerScript.enabled = true;
            _playerManager.enabled = true;
            
            chatOpen = false;
            firstPersonCamera.enabled = true;
            characterController.enabled = true;  
            mNetworkCharacterController.enabled = true;  
            
            runner.ProvideInput = true;
            
            // Cursor.lockState = CursorLockMode.Locked;  
            // Cursor.visible = false;
            
        }
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interaction.SetActive(true);
            enterOk = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        ChatText.SetActive(false);
        
        if (other.gameObject.CompareTag("Player"))
        {
            interaction.SetActive(false);
            enterOk = false;
        }
    }
}


