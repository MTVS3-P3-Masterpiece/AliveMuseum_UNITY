using System.Collections;
using Fusion;
using UnityEngine;

public class TalkingToChange : MonoBehaviour
{
       public GameObject viewPos;
    public GameObject interaction;
    public GameObject ChatText;
    bool enterOk = false;
    bool chatOpen1 = false;
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
        
    }


    void Update()
    {
        if (enterOk == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChatText.SetActive(true);
                chatOpen1 = true;
                followPlayer = true;  
                //interaction.SetActive(true);
                interaction.SetActive(false);
                
            }
        }

        if (followPlayer && player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        }
        
        if (Input.GetKeyDown(KeyCode.X) && chatOpen1)
        {
            ChatText.SetActive(false);
            _playerManager.enabled = true;
            
            chatOpen1 = false;
            firstPersonCamera.enabled = true;
            interaction.SetActive(false);            
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


